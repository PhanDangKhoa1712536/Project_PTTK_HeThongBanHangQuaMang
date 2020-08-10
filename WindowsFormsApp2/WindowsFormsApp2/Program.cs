﻿using System;
using System.Windows.Forms;

namespace Presentation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
    class NumericUpDownCell : DataGridViewTextBoxCell
    {
        public NumericUpDownCell() : base()
        {
            this.Style.Format = "0";
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            NumericCellControl nUpDown = DataGridView.EditingControl as NumericCellControl;

            // Use the default row value when Value property is null.
            if (this.Value == null)
            {
                nUpDown.Value = (Decimal)this.DefaultNewRowValue;
            }
            else
            {
                //nUpDown.Value = Decimal.Parse(this.Value.ToString());
                Object trueValue = this.Value;
                nUpDown.Value = Decimal.Parse(trueValue.ToString());
            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control 
                return typeof(NumericCellControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return base.ValueType;
            }
            set
            {
                base.ValueType = value;
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use 1.0 as the default value.
                return null;
            }
        }
    }
    public class NumericCellControl : NumericUpDown, IDataGridViewEditingControl
    {

        private bool Cancelling = false;

        public NumericCellControl()
        {
            this.Increment = 1m;
            this.DecimalPlaces = 1;
            this.Minimum = 1;
            this.Maximum = 100;
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue property.
        public Object EditingControlFormattedValue
        {
            get
            {
                // must return a String
                // it doesn't matter if the value is formatted, it will be replaced
                // by the formatting events
                return this.Value.ToString();
            }

            set
            {
                decimal val = 0;
                if (value is decimal)
                    val = (decimal)value;
                else
                {
                    String s = "" + value;
                    if (s.Length > 0)
                    {
                        decimal.TryParse(s, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out val);
                    }
                }

                if (val >= this.Minimum && val <= this.Maximum)
                    this.Value = val;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            if (!Cancelling)
            {
                var dgv = this.EditingControlDataGridView;
                var cell = (NumericUpDownCell)dgv.CurrentCell;
                cell.Value = this.Value;
            }

            base.OnLeave(e);
            Cancelling = false;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Cancelling = true;
                e.Handled = true;
                e.SuppressKeyPress = true;
                var dgv = this.EditingControlDataGridView;
                dgv.CancelEdit();
                dgv.EndEdit();
            }

            base.OnKeyDown(e);
        }

        // Implements the  IDataGridViewEditingControl.GetEditingControlFormattedValue method. 
        public Object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the IDataGridViewEditingControl.ApplyCellStyleToEditingControl method. 
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex property. 
        public int EditingControlRowIndex { get; set; }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey method. 
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.Escape:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit method. 
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        // Implements the IDataGridViewEditingControl.RepositionEditingControlOnValueChange property. 
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlDataGridView property. 
        public DataGridView EditingControlDataGridView { get; set; }

        // Implements the IDataGridViewEditingControl.EditingControlValueChanged property. 
        public bool EditingControlValueChanged { get; set; }

        // Implements the IDataGridViewEditingControl.EditingPanelCursor property. 
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }
    }
    public class NumericColumn : DataGridViewColumn
    {
        public NumericColumn() : base(new NumericUpDownCell())
        {
            this.ValueType = typeof(decimal?);
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is correct.
                if (value != null && !value.GetType().IsAssignableFrom(typeof(NumericUpDownCell)))
                {
                    throw new InvalidCastException("Must be a NumericUpDownCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}
