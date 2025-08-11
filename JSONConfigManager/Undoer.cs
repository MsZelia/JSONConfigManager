using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONConfigManager
{
    internal class Undoer
    {
        protected QuickScrollRichTextBox txtBox;
        protected List<Tuple<string, int>> LastData = new List<Tuple<string, int>>();
        protected int undoCount = 0;

        protected bool undoing = false;
        protected bool redoing = false;


        public Undoer(ref QuickScrollRichTextBox txtBox)
        {
            this.txtBox = txtBox;
            LastData.Add(new Tuple<string,int>(txtBox.Text, txtBox.SelectionStart));
        }

        public void undo_Click(object sender, EventArgs e)
        {
            this.Undo();
        }

        public void redo_Click(object sender, EventArgs e)
        {
            this.Redo();
        }

        public void Undo()
        {
            try
            {
                undoing = true;
                if (undoCount < LastData.Count - 1) ++undoCount;
                txtBox.Text = LastData[LastData.Count - undoCount - 1].Item1;
                txtBox.Select(LastData[LastData.Count - undoCount - 1].Item2, 0);
            }
            catch { }
            finally { this.undoing = false; }
        }

        public void Redo()
        {
            try
            {
                if (undoCount == 0)
                    return;

                redoing = true;
                --undoCount;
                txtBox.Text = LastData[LastData.Count - undoCount - 1].Item1;
                txtBox.Select(LastData[LastData.Count - undoCount - 1].Item2, 0);
            }
            catch { }
            finally { this.redoing = false; }
        }

        public void Save()
        {
            if (undoing || redoing)
                return;

            if (LastData[LastData.Count - 1].Item1 == txtBox.Text)
                return;

            LastData.Add(new Tuple<string, int>(txtBox.Text, txtBox.SelectionStart));
            undoCount = 0;
        }

        public void Clear()
        {
            undoCount = 0;
            LastData.Clear();
            LastData.Add(new Tuple<string, int>(txtBox.Text, txtBox.SelectionStart));
        }
    }
}
