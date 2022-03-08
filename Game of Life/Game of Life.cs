using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life
{
    public partial class Form1 : Form
    {
        BoardModel board;
        int generation;
        Color gridColor;
        int excessRemovedHeight;
        int excessRemovedWidth;

        // For drawing on bitmap
        Point lastPoint = Point.Empty;
        bool isMouseDown = new bool();
        int lockedCoordinateX; // The locked X coordinate for drawing a straight, vertical line
        int lockedCoordinateY; // The locked Y coordinate for drawing a straight, horizontal line
        Point hoverPoint; // The coordinate where the mouse is currently hovering

        public Form1()
        {
            InitializeComponent();

            GenerateBoard();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TickGame();
        }

        /// <summary>
        /// Change the size of the pixels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudSize_ValueChanged(object sender, EventArgs e)
        {
            board.CellSize = (int)nudSize.Value;
            
            ResizeBoard();

            Render();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            TogglePause();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            PauseGame();

            if (MessageBox.Show("This will start a new game with the selected parameters. Continue?", "Start new game", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                GenerateBoard();
            }

            UnpauseGame();
        }

        private void btnTick_Click(object sender, EventArgs e)
        {
            TickGame();
        }

        private void nudDelay_ValueChanged(object sender, EventArgs e)
        {
            if (nudDelay.Value > 0)
                timer1.Interval = (int)nudDelay.Value;
            else
                nudDelay.Value = 1;
        }

        private void btnSimGens_Click(object sender, EventArgs e)
        {
            generation += (int)nudSimGens.Value;
            lblGeneration.Text = "Generation " + generation.ToString() + " | Living cells: " + board.LivingCells.ToString();

            for (int i = (int)nudSimGens.Value; i > 0; i--)
            {
                TickGameLogic();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            PauseGame();
            Reset();
        }

        private void pbBoard_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isMouseDown = true;

            // Lock the proper coordinate for straight line drawing
            lockedCoordinateX = e.Location.X;
            lockedCoordinateY = e.Location.Y;

            if (lastPoint != null) //if our last point is not null, which in this case we have assigned above
            {
                if (pbBoard.Image == null) //if no available bitmap exists on the picturebox to draw on
                {
                    Bitmap bmp = new Bitmap(pbBoard.Width, pbBoard.Height); //create a new bitmap

                    pbBoard.Image = bmp; //assign the picturebox.Image property to the bitmap created
                }

                using (var cellBrush = new SolidBrush(colorDialog1.Color))
                using (var del_cellBrush = new SolidBrush(Color.Black))
                using (Graphics g = Graphics.FromImage(pbBoard.Image))

                {
                    var cellSize = (board.CellSize > 1) ?
                    new Size(board.CellSize - 1, board.CellSize - 1) :
                    new Size(board.CellSize, board.CellSize);

                    switch (e.Button)
                    {
                        case MouseButtons.Left:

                            // Calculate cell position
                            int PointX = 0;
                            int PointY = 0;

                            if (cbLine.Checked)
                            {
                                PointX = (int)Math.Floor((float)lockedCoordinateX / board.CellSize) * board.CellSize;
                            }
                            else
                            {
                                PointX = (int)Math.Floor((float)e.Location.X / board.CellSize) * board.CellSize;
                            }

                            if (cbHorLine.Checked)
                            {
                                PointY = (int)Math.Floor((float)lockedCoordinateY / board.CellSize) * board.CellSize;
                            }
                            else
                            {
                                PointY = (int)Math.Floor((float)e.Location.Y / board.CellSize) * board.CellSize;
                            }

                            var newCellLocation = new Point(PointX, PointY);
                            var cellRect = new Rectangle(newCellLocation, cellSize);
                            g.FillRectangle(cellBrush, cellRect);

                            try
                            {
                                board.Cells[PointX / board.CellSize, PointY / board.CellSize] = true;
                            }
                            catch (Exception ex)
                            {
                                Console.Error.WriteLine(ex.Message + "\nIt seems you tried to draw outside of the board");
                            }
                            break;

                        case MouseButtons.Right:

                            // Calculate cell position
                            int del_PointX = (int)Math.Floor((float)e.Location.X / board.CellSize) * board.CellSize;
                            int del_PointY = (int)Math.Floor((float)e.Location.Y / board.CellSize) * board.CellSize;

                            var del_newCellLocation = new Point(del_PointX, del_PointY);
                            var del_cellRect = new Rectangle(del_newCellLocation, cellSize);
                            g.FillRectangle(del_cellBrush, del_cellRect);

                            try
                            {
                                board.Cells[del_PointX / board.CellSize, del_PointY / board.CellSize] = false;
                            }
                            catch (Exception ex)
                            {
                                Console.Error.WriteLine(ex.Message + "\nIt seems you tried to draw outside of the board");
                            }
                            break;

                        default:
                            break;
                    }
                }

                pbBoard.Invalidate();//refreshes the picturebox

                lastPoint = e.Location;//keep assigning the lastPoint to the current mouse position

            }
        }

        private void pbBoard_MouseMove(object sender, MouseEventArgs e)
        {

            if (isMouseDown == true) //check to see if the mouse button is down
            {
                if (lastPoint != null) //if our last point is not null, which in this case we have assigned above
                {
                    if (pbBoard.Image == null) //if no available bitmap exists on the picturebox to draw on
                    {
                        Bitmap bmp = new Bitmap(pbBoard.Width, pbBoard.Height); //create a new bitmap

                        pbBoard.Image = bmp; //assign the picturebox.Image property to the bitmap created
                    }

                    using (var cellBrush = new SolidBrush(colorDialog1.Color))
                    using (var del_cellBrush = new SolidBrush(Color.Black))
                    using (Graphics g = Graphics.FromImage(pbBoard.Image))

                    {
                        var cellSize = (board.CellSize > 1) ?
                        new Size(board.CellSize - 1, board.CellSize - 1) :
                        new Size(board.CellSize, board.CellSize);

                        switch (e.Button)
                        {
                            case MouseButtons.Left:

                                // Calculate cell position
                                int PointX = 0;
                                int PointY = 0;

                                if (cbLine.Checked)
                                {
                                    PointX = (int)Math.Floor((float)lockedCoordinateX / board.CellSize) * board.CellSize;
                                }
                                else
                                {
                                    PointX = (int)Math.Floor((float)e.Location.X / board.CellSize) * board.CellSize;
                                }

                                if (cbHorLine.Checked)
                                {
                                    PointY = (int)Math.Floor((float)lockedCoordinateY / board.CellSize) * board.CellSize;
                                }
                                else
                                {
                                    PointY = (int)Math.Floor((float)e.Location.Y / board.CellSize) * board.CellSize;
                                }

                                var newCellLocation = new Point(PointX, PointY);
                                var cellRect = new Rectangle(newCellLocation, cellSize);
                                g.FillRectangle(cellBrush, cellRect);

                                try
                                {
                                    board.Cells[PointX / board.CellSize, PointY / board.CellSize] = true;
                                }
                                catch (Exception ex)
                                {
                                    Console.Error.WriteLine(ex.Message + "\nIt seems you tried to draw outside of the board");
                                }
                                break;

                            case MouseButtons.Right:

                                // Calculate cell position
                                int del_PointX = (int)Math.Floor((float)e.Location.X / board.CellSize) * board.CellSize;
                                int del_PointY = (int)Math.Floor((float)e.Location.Y / board.CellSize) * board.CellSize;

                                var del_newCellLocation = new Point(del_PointX, del_PointY);
                                var del_cellRect = new Rectangle(del_newCellLocation, cellSize);
                                g.FillRectangle(del_cellBrush, del_cellRect);

                                try
                                {
                                    board.Cells[del_PointX / board.CellSize, del_PointY / board.CellSize] = false;
                                }
                                catch (Exception ex)
                                {
                                    Console.Error.WriteLine(ex.Message + "\nIt seems you tried to draw outside of the board");
                                }
                                break;

                            default:
                                break;
                        }
                    }

                    pbBoard.Invalidate();//refreshes the picturebox

                    lastPoint = e.Location;//keep assigning the lastPoint to the current mouse position

                }

            }

            else if (!timer1.Enabled)
            {
                int PointX = (int)Math.Floor((float)e.Location.X / board.CellSize) * board.CellSize;
                int PointY = (int)Math.Floor((float)e.Location.Y / board.CellSize) * board.CellSize;

                Console.WriteLine("X: " + Math.Round((float)e.Location.X).ToString() + " Y: " + Math.Round((float)e.Location.Y).ToString());

                Console.WriteLine("pX: " + PointX.ToString() + " pY: " + PointY.ToString());

                Point lastHoverPoint = hoverPoint;

                hoverPoint = new Point(PointX, PointY);

                var cellSize = (board.CellSize > 1) ?
                        new Size(board.CellSize - 1, board.CellSize - 1) :
                        new Size(board.CellSize, board.CellSize);

                using (Graphics g = Graphics.FromImage(pbBoard.Image))
                using (var lastHoverBrush = new SolidBrush(Color.Black))
                using (var restoreBrush = new SolidBrush(colorDialog1.Color))
                using (var hoverBrush = new SolidBrush(Color.DarkCyan))
                {
                    try
                    {
                        if (board.Cells[lastHoverPoint.X / board.CellSize, lastHoverPoint.Y / board.CellSize] == false)
                        {
                            var lastRect = new Rectangle(lastHoverPoint, cellSize);
                            g.FillRectangle(lastHoverBrush, lastRect);
                        }
                        else
                        {
                            // Restore alive status
                            var cellRect = new Rectangle(lastHoverPoint, cellSize);
                            g.FillRectangle(restoreBrush, cellRect);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Tried drawing outside of index.");
                    }

                    try
                    {
                        var cellRect = new Rectangle(hoverPoint, cellSize);
                        g.FillRectangle(hoverBrush, cellRect);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Tried drawing outside of index.");
                    }


                }

                pbBoard.Invalidate();
            }
        }



        private void pbBoard_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;

            lastPoint = Point.Empty; //set the previous point back to null if the user lets go of the mouse button
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbLine_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLine.Checked)
            {
                cbHorLine.Checked = false;
            }
        }

        private void cbHorLine_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHorLine.Checked)
            {
                cbLine.Checked = false;
            }
        }

        // Resize the playable area after resizing the window
        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeBoard();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

        }

        // *********************
        // * DRAWING FUNCTIONS *
        // *********************

        /// <summary>
        /// Renders the board once.
        /// </summary>
        private void Render()
        {
            try
            {
                using (var bmp = new Bitmap(pbBoard.Width, pbBoard.Height))
                using (var gfx = Graphics.FromImage(bmp))
                using (var cellBrush = new SolidBrush(colorDialog1.Color))
                using (var hoverBrush = new SolidBrush(Color.DarkCyan))
                using (var emptyBrush = new SolidBrush(Color.Black))
                {
                    gfx.Clear(Color.DarkGray);

                    var cellSize = (board.CellSize > 1) ?
                                    new Size(board.CellSize - 1, board.CellSize - 1) :
                                    new Size(board.CellSize, board.CellSize);

                    for (int col = 0; col < board.Col; col++)
                    {
                        for (int row = 0; row < board.Row; row++)
                        {
                            var cell = board.Cells[row, col];
                            if (cell)
                            {
                                var cellLocation = new Point(row * board.CellSize, col * board.CellSize);
                                var cellRect = new Rectangle(cellLocation, cellSize);
                                gfx.FillRectangle(cellBrush, cellRect);
                            }
                            else
                            {
                                var squareLocation = new Point(row * board.CellSize, col * board.CellSize);
                                var squareRect = new Rectangle(squareLocation, cellSize);
                                gfx.FillRectangle(emptyBrush, squareRect);
                            }
                        }
                    }

                    pbBoard.Image = (Bitmap)bmp.Clone();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(board.Width + " " + board.Height);

                using (var bmp = new Bitmap(board.Width, board.Height))
                using (var gfx = Graphics.FromImage(bmp))
                using (var cellBrush = new SolidBrush(colorDialog1.Color))
                using (var hoverBrush = new SolidBrush(Color.Red))
                {
                    gfx.Clear(Color.Black);

                    var cellSize = (board.CellSize > 1) ?
                                    new Size(board.CellSize - 1, board.CellSize - 1) :
                                    new Size(board.CellSize, board.CellSize);

                    for (int col = 0; col < board.Col; col++)
                    {
                        for (int row = 0; row < board.Row; row++)
                        {
                            var cell = board.Cells[row, col];
                            if (cell)
                            {
                                var cellLocation = new Point(row * board.CellSize, col * board.CellSize);
                                var cellRect = new Rectangle(cellLocation, cellSize);
                                gfx.FillRectangle(cellBrush, cellRect);
                            }
                        }
                    }

                    pbBoard.Image = (Bitmap)bmp.Clone();
                }
            }
        }

        /// <summary>
        /// Clear the board of all living cells.
        /// </summary>
        private void ClearBoard()
        {
            for (int col = 0; col < board.Col; col++)
            {
                for (int row = 0; row < board.Row; row++)
                {
                    board.Cells[row, col] = false;
                }
            }

            Render(); // Renders the now cleared board.
        }

        // ******************************
        // * GAME MANAGER FUNCTIONALITY *
        // ******************************

        /// <summary>
        /// Ticks game and draws to board.
        /// </summary>
        private void TickGame()
        {
            board.Grow();
            Render();

            generation++;
            lblGeneration.Text = "Generation " + generation.ToString() + " | Living cells: " + board.LivingCells.ToString();
        }

        /// <summary>
        /// Reset the game (counters, etc.)
        /// </summary>
        public void Reset()
        {
            generation = 0;
            board.LivingCells = 0;
            lblGeneration.Text = "Generation " + generation.ToString() + " | Living cells: " + board.LivingCells.ToString();

            ClearBoard();
        }

        /// <summary>
        /// Generates a board for the game of life.
        /// </summary>
        public void GenerateBoard()
        {
            board = new BoardModel(
                r: (pbBoard.Width / (int)nudSize.Value) + (int)nudSize.Value,
                c: (pbBoard.Height / (int)nudSize.Value) + (int)nudSize.Value,
                cellSize: (int)nudSize.Value,
                liveDensity: (double)nudDensity.Value / 100);
        }

        /// <summary>
        /// Resize the board
        /// </summary>
        private void ResizeBoard()
        {
            if (pbBoard.Width > 0 && pbBoard.Height > 0)
            {

                int newRow = (pbBoard.Width / (int)nudSize.Value) + (int)nudSize.Value;
                int newCol = (pbBoard.Height / (int)nudSize.Value) + (int)nudSize.Value;

                board.CellSize = (int)nudSize.Value;
                board.LiveDensity = (double)nudDensity.Value / 100;

                bool[,] newCells = new bool[newRow, newCol];

                for (int col = 0; col < board.Col; col++)
                {
                    for (int row = 0; row < board.Row; row++)
                    {
                        if (!(row > (newRow - 1)))
                        {
                            if (!(col > (newCol - 1)))
                                newCells[row, col] = board.Cells[row, col];
                        }
                    }
                }

                board.Col = newCol;
                board.Row = newRow;

                board.Cells = newCells;

                try
                {
                    Render();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        // TIME CONTROLS

        /// <summary>
        /// Pauses the game if the game is unpaused.
        /// </summary>
        public void PauseGame()
        {
            if (timer1.Enabled)
            {
                TogglePause();

            }
        }
        
        /// <summary>
        /// Unpauses the game if it is currently paused.
        /// </summary>
        public void UnpauseGame()
        {
            if (!timer1.Enabled)
            {
                TogglePause();
            }
        }

        /// <summary>
        /// Toggles between the paused/unpaused state.
        /// </summary>
        public void TogglePause()
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                Controls["btnPause"].Text = "Go";

            }
            else
            {
                timer1.Enabled = true;
                Controls["btnPause"].Text = "Pause";
            }

        }

        /// <summary>
        /// Ticks game without rendering output. Doesn't update the generations label, either.
        /// </summary>
        private void TickGameLogic()
        {
            board.Grow();
        }
    }
}
