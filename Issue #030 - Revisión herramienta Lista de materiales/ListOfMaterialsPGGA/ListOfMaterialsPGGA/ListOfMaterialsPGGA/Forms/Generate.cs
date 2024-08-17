﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interface.ExcelTools;
using ListOfMaterialsPGGA.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace ListOfMaterialsPGGA
{
    public partial class Generate : Form
    {
        const Int32 blank_color = 0xFFFFFF;
        const Int32 warning_color = 0x00FFFF;
        const Int32 new_row_color = 0xE0A413; // #13a4e0
        const string quote = "\"";
        const int col_item = 1;
        const int col_desc = 2;
        const int col_codefab = 7;
        //const int col_need = 8;
        const int col_need = 12;
        const int col_need_total = 8;
        //const int col_build = 9;
        const int col_build = 12;
        //const int col_saldo = 10;
        const int col_saldo = 14;
        //const int col_resp = 11;
        const int col_resp = 15;

        public Generate()
        {
            InitializeComponent();
        }

        private void Generate_Load(object sender, EventArgs e)
        {
            //using some code here to step on the template file, because I really dislike using the Excel Interface code

            string oldPathName = System.IO.Directory.GetCurrentDirectory() + "\\Template_2.xlsm";
            string newPathName = System.IO.Directory.GetCurrentDirectory() + "\\Template.xlsm";

            try
            {
                System.IO.File.Copy(oldPathName, newPathName, true);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //this.picbox_template.Image = new Bitmap(Properties.Resources.uncheck, new Size(24, 24));
            this.picbox_save.Image = new Bitmap(Properties.Resources.uncheck, new Size(24, 24));
            this.tb_template.Text = System.IO.Directory.GetCurrentDirectory() + "\\Template.xlsm";
            this.tb_path.Text = System.IO.Directory.GetCurrentDirectory() + "\\";
            this.tb_save.Text = "Report-" + DateTime.Now.ToString("yyyy-MM-dd") + "-BillOfMaterial.xlsm";
            this.st_label.Text = "Inicio del programa";
            this.mensaje.Update();
        }

        private void Fill_template()
        {
            this.st_label.Text = "";
            this.mensaje.Update();
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.InitialDirectory = "c:\\";
            ofd.Filter = "Excel (*.xls, *.xlsx, *.xlsm)|*.xls;*.xlsx;*.xlsm|All Files (*.*)|*.*";
            ofd.FilterIndex = 2;
            //ofd.RestoreDirectory = true;

            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.tb_template.Text = ofd.FileName;
            }
            ofd = null;
        }

        private void Fill_save()
        {
            this.st_label.Text = "";
            this.mensaje.Update();
            FolderBrowserDialog ofd = new FolderBrowserDialog();

            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.tb_path.Text = ofd.SelectedPath + "\\";
            }
            ofd = null;
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            this.st_label.Text = "";
            this.mensaje.Update();
            ExcelInterface obj = new ExcelInterface();
            string excelfilepath = string.Empty;
            excelfilepath = obj.GetFileNameFromDialog();

            obj.Dispose();
            obj = null;
            foreach(string selectedfile in excelfilepath.Split(';'))
            {
                if (selectedfile.Split('\\').Last() == tb_save.Text)
                {
                    MessageBox.Show("No se puede agregar un documento con el mismo nombre con el que va a ser guardado");
                }
                else if (selectedfile != "")
                {
                    string excelfilename = System.IO.Path.GetFileName(selectedfile);
                    System.Drawing.Bitmap icon = Properties.Resources.check;
                    icon = new Bitmap(icon, new Size(24, 24));
                    object[] tmp_data = new object[] { 
                    excelfilename, 
                    selectedfile,
                    1,
                    icon};
                    this.dataGridView1.Rows.Add(tmp_data);
                    tmp_data = null;
                    icon = null;
                    this.st_label.Text = "Documento agregado a la lista";
                    this.mensaje.Update();
                }
            }
        }

        private void bt_del_Click(object sender, EventArgs e)
        {
            this.st_label.Text = "";
            this.mensaje.Update();
            DataGridView dgv = this.dataGridView1;
            try
            {
                int totalRows = dgv.Rows.Count;
                if (totalRows == 0)
                    return;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow);
                dgv.ClearSelection();
                this.st_label.Text = "Documento borrado de la lista";
                this.mensaje.Update();
                if (dgv.Rows.Count == 0)
                    return;
                dgv.Rows[0].Selected = true;
            }
            catch { }
            dgv = null;
        }

        private void bt_up_Click(object sender, EventArgs e)
        {
            this.st_label.Text = "";
            this.mensaje.Update();
            DataGridView dgv = this.dataGridView1;
            try
            {
                int totalRows = dgv.Rows.Count;
                if (totalRows < 2)
                    return;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[ 0 ].OwningRow.Index;
                if ( rowIndex == 0 )
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[ 0 ].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[ rowIndex ];
                dgv.Rows.Remove( selectedRow );
                dgv.Rows.Insert( rowIndex - 1, selectedRow );
                dgv.ClearSelection();
                dgv.Rows[ rowIndex - 1 ].Cells[ colIndex ].Selected = true;
            }
            catch { }
            dgv = null;
        }

        private void bt_down_Click(object sender, EventArgs e)
        {
            this.st_label.Text = "";
            this.mensaje.Update();
            DataGridView dgv = this.dataGridView1;
            try
            {
                int totalRows = dgv.Rows.Count;
                if (totalRows < 2)
                    return;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow);
                dgv.Rows.Insert(rowIndex + 1, selectedRow);
                dgv.ClearSelection();
                dgv.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
            }
            catch { }
            dgv = null;
        }

        private void bt_Sumar_Click(object sender, EventArgs e)
        {
            this.st_label.Text = "";
            this.mensaje.Update();
            DataGridView dgv = this.dataGridView1;
            try
            {
                int totalRows = dgv.Rows.Count;
                if (totalRows == 0)
                    return;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                int value = Convert.ToInt32(selectedRow.Cells[2].Value);
                value++;
                selectedRow.Cells[2].Value = value;
            }
            catch { }
            dgv = null;
        }

        private void bt_Restar_Click(object sender, EventArgs e)
        {
            this.st_label.Text = "";
            this.mensaje.Update();
            DataGridView dgv = this.dataGridView1;
            try
            {
                int totalRows = dgv.Rows.Count;
                if (totalRows == 0)
                    return;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                int value = Convert.ToInt32(selectedRow.Cells[2].Value);
                value--;
                if (value > 0)
                    selectedRow.Cells[2].Value = value;
            }
            catch { }
            dgv = null;
        }

        private void bt_template_Click(object sender, EventArgs e)
        {
            Fill_template();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            Fill_save();
        }

        private void tb_template_DoubleClick(object sender, EventArgs e)
        {
            Fill_template();
        }

        private void tb_path_DoubleClick(object sender, EventArgs e)
        {
            Fill_save();
        }

        private void tb_template_TextChanged(object sender, EventArgs e)
        {
            //if (System.IO.File.Exists(this.tb_template.Text))
            //    this.picbox_template.Image = new Bitmap(Properties.Resources.check, new Size(24, 24));
            //else
            //    this.picbox_template.Image = new Bitmap(Properties.Resources.uncheck, new Size(24, 24));
        }

        private void tb_save_TextChanged(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(System.IO.Path.Combine(this.tb_path.Text, this.tb_save.Text)))
                this.picbox_save.Image = new Bitmap(Properties.Resources.check, new Size(24, 24));
            else
                this.picbox_save.Image = new Bitmap(Properties.Resources.uncheck, new Size(24, 24));
        }

        private void bt_out_open_Click(object sender, EventArgs e)
        {
            try
            {
                string filepath = this.tb_path.Text;
                Boolean found = false;
                System.Diagnostics.ProcessStartInfo StartInformation = new System.Diagnostics.ProcessStartInfo();
                while (!found)
                {
                    StartInformation.FileName = filepath;
                    try
                    {
                        System.Diagnostics.Process process = System.Diagnostics.Process.Start(StartInformation);
                        process = null;
                        found = true;
                    }
                    catch { }
                    int ultimo = filepath.LastIndexOf('\\');
                    filepath = filepath.Remove(ultimo);
                }
                StartInformation = null;
            }
            catch { }
        }

        //private void btn_gojoiner_Click(object sender, EventArgs e)
        //{
        //    //this.Hide();
        //    //var form2 = new Joiner();
        //    //form2.Closed += (s, args) => this.Close();
        //    //form2.Show();
        //}

        private void bt_generate_Click(object sender, EventArgs e)
        {
            //abrir el template, grabar en un nuevo archivo
            this.st_label.Text = "Proceso para generar nuevo documento...";
            this.mensaje.Update(); 
            if (this.dataGridView1.Rows.Count < 1)
            {
                this.st_label.Text = "La lista no contiene documentos.";
                this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
                return;
            }
            if (!System.IO.File.Exists(this.tb_template.Text))
            {
                this.st_label.Text = "No se encontró el archivo template.";
                this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
                return;
            }
            if (this.tb_template.Text == (System.IO.Path.Combine(this.tb_path.Text, this.tb_save.Text)))
            {
                this.st_label.Text = "No debe usar el archivo de template como salida.";
                this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
                return;
            }

            this.st_label.Text = "Abriendo archivo template...";
            this.mensaje.Update();
            ExcelInterface objxls = null;
            try
            {
                objxls = new ExcelInterface();
                objxls.OpenFileToEdit(this.tb_template.Text);
            }
            catch
            {
                this.st_label.Text = "Error al conectarse con el programa Excel";
                this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
                return;
            }

            if (!objxls.SelectSheet("Referencia"))
            {
                if (!objxls.SelectSheet("Total"))
                {
                    objxls.CloseXLS();
                    objxls.ReleaseWithoutCloseXLS();
                    objxls = null;
                    this.st_label.Text = "El archivo template no contiene una hoja con nombre 'Total'.";
                    this.mensaje.Update();
                    MessageBox.Show(this.st_label.Text);
                    return;
                }
            }
            objxls.HideExcel();

            objxls.TrySaveAs(System.IO.Path.Combine(this.tb_path.Text, this.tb_save.Text));
            if (!System.IO.File.Exists(System.IO.Path.Combine(this.tb_path.Text, this.tb_save.Text)))
            {
                this.st_label.Text = "Problema al intentar guardar el archivo.";
                this.mensaje.Update();
                this.picbox_save.Image = new Bitmap(Properties.Resources.uncheck, new Size(24, 24));
                objxls.CloseXLS();
                objxls.ReleaseWithoutCloseXLS(); 
                objxls = null;
                //this.st_label.Text = "Problema al intentar guardar el archivo.";
                //this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
                return;
            }
            objxls.HideExcel();
            this.st_label.Text = "Archivo base creado correctamente, generando hojas...";
            this.mensaje.Update(); 
            this.picbox_save.Image = new Bitmap(Properties.Resources.check, new Size(24, 24));

            string filedir = string.Empty;
            string tempname = string.Empty;
            //recorrer los archivos de la lista, ir copiando toda la info en una nueva hoja
            //cada archivo de la lista debe ser abierto en modo lectura, sacar la info y cerrarlo
            //llenar una lista con cada archivo que se fue copiando
            int count = 0;
            try
            {

                foreach (var item in this.dataGridView1.Rows)
                {

                    filedir = (string)((DataGridViewRow)item).Cells[1].Value;
                    objxls.bookmem = objxls.app.Workbooks.Open(filedir, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, 0);
                    if (objxls.bookmem != null)
                    {
                        tempname = (string)((DataGridViewRow)item).Cells[0].Value;
                        try {
                            tempname = tempname.Substring(0, 28);
                        }     //Para nombres de archivos tipo Q
                        catch {
                        }
                        tempname = tempname.Replace(".", "-");

                        foreach (Excel.Worksheet wksht in objxls.bookmem.Worksheets)
                        {
                            Dictionary<string, Tuple<int, Int32>> dict_comp = new Dictionary<string, Tuple<int, Int32>>();
                            bool sht_dup = false;

                            if (wksht.Name == "BoMList")
                            {
                                objxls.sheetmem = wksht;
                                if (objxls.sheetmem != null)
                                {
                                    count++;
                                    this.st_label.Text = "Copiando " + count + "/" + this.dataGridView1.RowCount + " ...";
                                    this.mensaje.Update();

                                    if (objxls.SelectSheet(tempname)) //significa que hay que acoplar los números
                                    {

                                        sht_dup = true;
                                        objxls.SelectSheet(tempname);
                                        objxls.worksheet.Name = "Duplicate";

                                        objxls.sheetmem.Copy(Type.Missing, (objxls.worksheet)); //copiamos el sheet
                                        objxls.SelectSheet("BoMList");
                                        objxls.worksheet.Name = tempname;

                                        objxls.SelectSheet("Duplicate");

                                        List<string> sheets = new List<string> { "Duplicate", tempname };

                                        foreach(string sht in sheets)
                                        {
                                            objxls.SelectSheet(sht);

                                            int n_quantity = 0;

                                            if (((objxls.worksheet.Cells[3, 11] as Excel.Range).Text.ToString()) == "QUANTITY") n_quantity = 11;
                                            else n_quantity = 8;

                                            for (int i = 4; i < 60; i++)
                                            {
                                                string key_comp = "";

                                                for (int j = 2; j < 8; j++) //esto lo que hace es crear el identificador en base a las primeras 6 columnas
                                                {
                                                    key_comp += (objxls.worksheet.Cells[i, j] as Excel.Range).Text.ToString() + ";";
                                                }

                                                if (!dict_comp.ContainsKey(key_comp))
                                                {
                                                    try
                                                    {
                                                        if(sht == "Duplicate") {
                                                            //If its the first sheet, then its not highlighted
                                                            dict_comp.Add(key_comp, new Tuple<int, Int32>(Int32.Parse((objxls.worksheet.Cells[i, n_quantity] as Excel.Range).Text.ToString()), blank_color));
                                                        } else {
                                                            dict_comp.Add(key_comp, new Tuple<int, Int32>(Int32.Parse((objxls.worksheet.Cells[i, n_quantity] as Excel.Range).Text.ToString()), new_row_color));
                                                        }
                                                    }
                                                    catch (Exception exc) { string error = exc.ToString(); }
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        //If the value is different to the one already in the dictionary => have to highlight it
                                                        if (dict_comp[key_comp].Item1 != Int32.Parse((objxls.worksheet.Cells[i, n_quantity] as Excel.Range).Text.ToString()))
                                                        {
                                                            //Simply changing the value of the number of items available
                                                            dict_comp[key_comp] = new Tuple<int, Int32>(Int32.Parse((objxls.worksheet.Cells[i, n_quantity] as Excel.Range).Text.ToString()), warning_color);
                                                            //dict_comp[key_comp].Item1 = Int32.Parse((objxls.worksheet.Cells[i, n_quantity] as Excel.Range).Text.ToString());

                                                            objxls.SelectSheet(tempname);
                                                        }
                                                    }
                                                    catch (Exception exc) { string error = exc.ToString(); }
                                                }
                                            }
                                        }

                                        objxls.SelectSheet(tempname);

                                        int n_row = 4;

                                        foreach (KeyValuePair<string, Tuple<int, Int32>> entry in dict_comp)
                                        {
                                            string[] descriptions = entry.Key.Split(';');

                                            objxls.worksheet.Cells[n_row, 1] = n_row-3;

                                            for (int j = 2; j <= 8; j++) //pasting all the values of the descriptions
                                            {
                                                objxls.worksheet.Cells[n_row, j] = descriptions[j-2];
                                            }

                                            objxls.worksheet.Cells[n_row, 11] = entry.Value.Item1; //pasting the value of the quantity
                                            //objxls.worksheet.get_Range(objxls.worksheet.Cells[n_row, 11], objxls.worksheet.Cells[n_row, 11]).Interior.Color = entry.Value.Item2;
                                            objxls.worksheet.get_Range(objxls.worksheet.Cells[n_row, 11], objxls.worksheet.Cells[n_row, 11]).Interior.Color = entry.Value.Item2;

                                            if(entry.Value.Item2 == new_row_color)
                                            {
                                                objxls.worksheet.get_Range(objxls.worksheet.Cells[n_row, 1], objxls.worksheet.Cells[n_row, 11]).Interior.Color = entry.Value.Item2;
                                            }

                                            n_row++;
                                        }

                                        for (int i = objxls.workbook.Worksheets.Count; i > 0; i--) //busca y borra la hoja 'Duplicate'
                                        {
                                            Worksheet wkSheet = (Worksheet)objxls.workbook.Worksheets[i];
                                            if (wkSheet.Name == "Duplicate")
                                            {
                                                objxls.app.DisplayAlerts = false;
                                                wkSheet.Delete();
                                                objxls.app.DisplayAlerts = true;
                                            }
                                        }

                                    } else {
                                        objxls.sheetmem.Copy(Type.Missing, (objxls.worksheet));
                                        objxls.SelectSheet("BoMList");

                                        objxls.worksheet.Name = tempname;

                                    }

                                    objxls.SelectSheet(tempname);

                                    //Nombra los headers
                                    objxls.worksheet.Cells[1, 4] = "Cantidad";
                                    objxls.worksheet.Cells[3, 8] = "ICT";
                                    objxls.worksheet.Cells[3, 9] = "SAP ID";
                                    objxls.worksheet.Cells[3, 10] = "";

                                    objxls.worksheet.Cells[3, 11] = "QUANTITY";
                                    objxls.worksheet.Cells[3, 12] = "Agregar a reporte HW/SW";
                                    objxls.worksheet.Cells[3, 13] = "Agregar a Repuestos";
                                    objxls.worksheet.Cells[3, 14] = "Agregar a Sueltos";
                                    objxls.worksheet.Cells[3, 15] = "Comentarios/Seguimiento";

                                    objxls.worksheet.get_Range(objxls.worksheet.Cells[3, 12], objxls.worksheet.Cells[3, 15]).Font.Color = Excel.XlRgbColor.rgbWhite;
                                    objxls.worksheet.get_Range(objxls.worksheet.Cells[3, 12], objxls.worksheet.Cells[3, 15]).Font.Bold = true;

                                    objxls.worksheet.get_Range(objxls.worksheet.Cells[3, 12], objxls.worksheet.Cells[3, 15]).Interior.Color = 0x808080;

                                    objxls.worksheet.get_Range(objxls.worksheet.Cells[3, 8], objxls.worksheet.Cells[3, 8]).Font.Color = Excel.XlRgbColor.rgbBlack;
                                    objxls.worksheet.get_Range(objxls.worksheet.Cells[3, 11], objxls.worksheet.Cells[3, 11]).Font.Color = Excel.XlRgbColor.rgbBlack;

                                    objxls.worksheet.get_Range(objxls.worksheet.Cells[3, 8], objxls.worksheet.Cells[200, 15]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    objxls.worksheet.get_Range(objxls.worksheet.Cells[3, 8], objxls.worksheet.Cells[200, 15]).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                                    int count_rows = 3; 

                                    for (int p = 3; p < 200; p++)
                                    {
                                        //if(objxls.worksheet.)
                                        if (((objxls.worksheet.Cells[p, 1] as Excel.Range).Value) == null)
                                        {
                                            break;
                                        }
                                        else 
                                        {
                                            count_rows = p;
                                            if ((warning_color != Convert.ToInt32(objxls.worksheet.get_Range(objxls.worksheet.Cells[p, 11], objxls.worksheet.Cells[p, 11]).Interior.Color)) &&
                                                (new_row_color != Convert.ToInt32(objxls.worksheet.get_Range(objxls.worksheet.Cells[p, 11], objxls.worksheet.Cells[p, 11]).Interior.Color)))
                                            {
                                                objxls.worksheet.get_Range(objxls.worksheet.Cells[p, 11], objxls.worksheet.Cells[p, 11]).Interior.Color = 0xC07000;
                                            }

                                            //Agrega los colores respectivos

                                            if (p != 3)
                                            {
                                                if (!sht_dup)
                                                { //copia las cantidades si es que no fue duplicado.
                                                    objxls.worksheet.Cells[p, 11] = objxls.worksheet.Cells[p, 8];
                                                    objxls.worksheet.Cells[p, 15] = objxls.worksheet.Cells[p, 12];

                                                    System.Threading.Thread.Sleep(10);

                                                }

                                                objxls.worksheet.Cells[p, 9] = objxls.worksheet.Cells[p, 7];

                                                objxls.worksheet.Cells[p, 10] = "";
                                                objxls.worksheet.Cells[p, 8] = "L";

                                                objxls.worksheet.Cells[p, 12] = ('\u2713').ToString();
                                                objxls.worksheet.Cells[p, 13] = ('\u2713').ToString();
                                                objxls.worksheet.Cells[p, 14] = ('\u2713').ToString();

                                                //Char('HD7')"\uHD7";

                                                objxls.worksheet.Columns.AutoFit();

                                                //Excel.Range range = objxls.worksheet.Range;
                                                //Excel.Range cell = range.Cells[p, 15];
                                                //Excel.Borders border = cell.Borders;

                                                //border.LineStyle = Excel.XlLineStyle.xlContinuous;
                                                //border.Weight = 2d;
                                            }

                                            //((Range)objxls.worksheet.Cells[100, 15]).Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                                            //((Range)objxls.worksheet.Cells[100, 15]).Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 3d;
                                            //((Range) objxls.worksheet.get_Range(objxls.worksheet.Cells[7, 76], objxls.worksheet.Cells[11, 94]))
                                            
                                            //objxls.worksheet.getRange("G76:K94");
                                        }
                                    }

                                    ((Range)objxls.worksheet.get_Range("A3:O44")).Cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                                    ((Range)objxls.worksheet.get_Range("A3:O44")).Cells.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 2d;
                                    ((Range)objxls.worksheet.get_Range("A3:O44")).Cells.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 2d;
                                    ((Range)objxls.worksheet.get_Range("A4:O44")).Cells.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 3d;
                                    ((Range)objxls.worksheet.get_Range("A3:O44")).Cells.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;
                                    ((Range)objxls.worksheet.get_Range("A3:O3")).Cells.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 2d;

                                    objxls.worksheet.get_Range(objxls.worksheet.Cells[4, 12], objxls.worksheet.Cells[count_rows, 14]).Font.Bold = true;
                                    objxls.worksheet.get_Range(objxls.worksheet.Cells[4, 12], objxls.worksheet.Cells[count_rows, 14]).Font.Size = 14;
                                    objxls.worksheet.get_Range(objxls.worksheet.Cells[4, 12], objxls.worksheet.Cells[count_rows, 14]).Font.Color = 0x1f8a13; //#138a1f
                                    objxls.worksheet.get_Range(objxls.worksheet.Cells[3, 8], objxls.worksheet.Cells[count_rows, 8]).Interior.Color = 0xC07000;
                                    objxls.worksheet.get_Range(objxls.worksheet.Cells[3, 9], objxls.worksheet.Cells[count_rows, 10]).Interior.Color = 0x00C0FF;

                                    try
                                    {
                                        objxls.worksheet.Cells[1, 5] = ((DataGridViewRow)item).Cells[2].Value;
                                    }
                                    catch
                                    {
                                        objxls.worksheet.Cells[1, 5] = 1;
                                    }

                                    if (Convert.ToString((objxls.worksheet.Cells[3, 6] as Excel.Range).Text) == "ArticleNumber")
                                    {
                                        (objxls.worksheet.Cells[1, 6] as Excel.Range).EntireColumn.Delete(Excel.XlDeleteShiftDirection.xlShiftToLeft);
                                    }

                                    break;
                                }
                            }
                            //acá se fija si es del otro tipo de formato de workbook
                            else if ((wksht.Name != "Cover page") && (wksht.Name != "BoMListMechanical") && (wksht.Name != "CaratulaABB") && (wksht.Name != "Total") 
                                && (wksht.Name != "ComponentData") && (wksht.Name != "Referencia"))
                            {
                                objxls.sheetmem = wksht;
                                if (objxls.sheetmem != null)
                                {
                                    count++;
                                    this.st_label.Text = "Copiando " + count + "/" + this.dataGridView1.RowCount + " ...";
                                    this.mensaje.Update();
                                    
                                    if (objxls.SelectSheet(tempname))
                                    {
                                        objxls.SelectSheet(tempname);
                                        objxls.worksheet.Name = "Duplicate";
                                        objxls.sheetmem.Copy(Type.Missing, (objxls.worksheet));
                                        objxls.SelectSheet("Duplicate");

                                        List<string> sheets = new List<string> { "Duplicate", tempname };
                                        //Dictionary<string, int> dict_comp = new Dictionary<string, int>();

                                        foreach (string sht in sheets)
                                        {
                                            int n_quantity = 0;
                                            if (((objxls.worksheet.Cells[3, 11] as Excel.Range).Text.ToString()) == "QUANTITY") n_quantity = 11;
                                            else n_quantity = 8;

                                            objxls.SelectSheet(sht);

                                            for (int i = 4; i < 60; i++)
                                            {
                                                string key_comp = "";

                                                for (int j = 2; j < 8; j++)
                                                {
                                                    key_comp += (objxls.worksheet.Cells[i, j] as Excel.Range).Text.ToString() + ";";
                                                }

                                                if (!dict_comp.ContainsKey(key_comp))
                                                {
                                                    try
                                                    {
                                                        if(sht == "Duplicate")
                                                        {
                                                            dict_comp.Add(key_comp, new Tuple<int, Int32>(Int32.Parse((objxls.worksheet.Cells[i, n_quantity] as Excel.Range).Text.ToString()), blank_color));
                                                        } else
                                                        {
                                                            dict_comp.Add(key_comp, new Tuple<int, Int32>(Int32.Parse((objxls.worksheet.Cells[i, n_quantity] as Excel.Range).Text.ToString()), warning_color));
                                                        }
                                                    }
                                                    catch (Exception exc) { string error = exc.ToString(); }
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        if (dict_comp[key_comp].Item1 != Int32.Parse((objxls.worksheet.Cells[i, n_quantity] as Excel.Range).Text.ToString()))
                                                        {
                                                            dict_comp[key_comp] = new Tuple<int, Int32> (Int32.Parse((objxls.worksheet.Cells[i, n_quantity] as Excel.Range).Text.ToString()), new_row_color);

                                                            //objxls.worksheet.get_Range(objxls.worksheet.Cells[i, n_quantity], objxls.worksheet.Cells[i, n_quantity]).Interior.Color = warning_color;
                                                            objxls.worksheet.get_Range(objxls.worksheet.Cells[i, 1], objxls.worksheet.Cells[i, 1]).Interior.Color = warning_color;
                                                        }
                                                    }
                                                    catch (Exception exc) { string error = exc.ToString(); }
                                                }
                                            }
                                        }

                                        objxls.SelectSheet(tempname);

                                        int n_row = 4;

                                        foreach (KeyValuePair<string, Tuple<int, Int32>> entry in dict_comp)
                                        {
                                            string[] descriptions = entry.Key.Split(';');

                                            objxls.worksheet.Cells[n_row, 1] = n_row - 3;

                                            for (int j = 2; j < 8; j++)
                                            {
                                                objxls.worksheet.Cells[n_row, j] = descriptions[j - 2];
                                            }

                                            objxls.worksheet.Cells[n_row, 11] = entry.Value.Item1;
                                            //objxls.worksheet.get_Range(objxls.worksheet.Cells[n_row, 11], objxls.worksheet.Cells[n_row, 11]).Interior.Color = entry.Value.Item2;
                                            objxls.worksheet.get_Range(objxls.worksheet.Cells[n_row, 11], objxls.worksheet.Cells[n_row, 11]).Interior.Color = entry.Value.Item2;

                                            if(entry.Value.Item2 == new_row_color)
                                            {
                                                objxls.worksheet.get_Range(objxls.worksheet.Cells[n_row, 1], objxls.worksheet.Cells[n_row, 11]).Interior.Color = entry.Value.Item2;
                                            }

                                            n_row++;
                                        }

                                        for (int i = objxls.workbook.Worksheets.Count; i > 0; i--)
                                        {
                                            Worksheet wkSheet = (Worksheet)objxls.workbook.Worksheets[i];
                                            if (wkSheet.Name == "Duplicate")
                                            {
                                                objxls.app.DisplayAlerts = false;
                                                wkSheet.Delete();
                                                objxls.app.DisplayAlerts = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        objxls.sheetmem.Copy(Type.Missing, (objxls.worksheet));
                                        objxls.SelectSheet(wksht.Name);
                                    }
                                }
                            }
                        }
                        objxls.bookmem.Close(false, false, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);

                this.st_label.Text = "Error al adquirir datos de los documentos";
                this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
                objxls.CloseXLS();
                objxls.ReleaseWithoutCloseXLS();
                objxls.Dispose();
                objxls = null;
                return;
            }

            try
            {
                objxls.workbook.Save();
                objxls.SelectSheet("Total");
                this.st_label.Text = "Plantilla de proyecto generada";
                this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
            }
            catch
            {
                this.st_label.Text = "Error al intentar guardar el archivo";
                this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
            }
            objxls.ShowExcel();
            objxls.Dispose();
            objxls = null;
            return;
        }

        private void bt_total_Click(object sender, EventArgs e)
        {
            this.st_label.Text = "Proceso para generar hoja de totales...";
            try
            {
                this.mensaje.Update();
                if (!System.IO.File.Exists(System.IO.Path.Combine(this.tb_path.Text, this.tb_save.Text)))
                {
                    this.picbox_save.Image = new Bitmap(Properties.Resources.uncheck, new Size(24, 24));
                    this.st_label.Text = "El archivo no existe...";
                    this.mensaje.Update();
                    MessageBox.Show(this.st_label.Text);
                    return;
                }
                this.st_label.Text = "Conectando con el archivo excel...";
                this.mensaje.Update();
            }
            catch
            {
                this.st_label.Text = "Error al buscar el archivo de Excel";
                this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
                return;
            }
            ExcelInterface objxls = null;
            try
            {
                objxls = new ExcelInterface();
                if (!objxls.FindDocument(System.IO.Path.Combine(this.tb_path.Text,this.tb_save.Text)))
                {
                    this.st_label.Text = "Error al conectarse con el archivo de Excel";
                    this.mensaje.Update();
                    MessageBox.Show(this.st_label.Text);
                    return;
                }
            }
            catch
            {
                this.st_label.Text = "Error al conectarse con el archivo de Excel";
                this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
                objxls = null;
                return;
            }
            //objxls.OpenFileToEdit(System.IO.Path.Combine(this.tb_path.Text,this.tb_save.Text));
            if (!objxls.SelectSheet("Total"))
            {
                this.st_label.Text = "Error: El archivo excel no contiene una hoja denominada Total";
                this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
                objxls.ShowExcel();
                objxls.Dispose();
                objxls = null;
                return;
            }

            // HASTA ACA ESTA TODO BIEN


            //objxls.ShowExcel();
            Dictionary<string, int> l_data = new Dictionary<string, int>();
            Dictionary<string, string> l_resp = new Dictionary<string, string>();
            //objxls.worksheet.Select();
            objxls.HideExcel();

            int countaux = 1;
            string straux = string.Empty;
            long row, col;
            int quantity;
            int hojas;
            this.st_label.Text = "Tomando información...";
            this.mensaje.Update();
            hojas = 0;
            try
            {
                foreach (Excel.Worksheet wksht in objxls.workbook.Worksheets)
                {
                    if ((wksht.Name != "Total") && (wksht.Name != "CaratulaABB") && (wksht.Name != "Referencia") && (wksht.Name != "Materiales") && (wksht.Name != "ComponentData"))
                    {
                        hojas++;
                        this.st_label.Text = "Tomando información " + (hojas) + "/" + (objxls.workbook.Worksheets.Count - 3) + " ...";
                        this.mensaje.Update();
                        objxls.worksheet = wksht;
                        if (objxls.worksheet != null)
                        {
                            countaux = 1;
                            row = 3;
                            try
                            {
                                var n_cant_tip = (objxls.worksheet.Cells[1, 5] as Excel.Range).Text;
                                countaux = Convert.ToInt32(n_cant_tip);
                            }
                            catch
                            {
                                countaux = 1;
                            }
                            while ((objxls.worksheet.Cells[row + 1, 1] as Excel.Range).Text.ToString() != string.Empty)
                            {
                                row++;
                                try
                                {
                                    //var n_cant_item = (objxls.worksheet.Cells[row, col_need] as Excel.Range).Text;
                                    var n_cant_item = (objxls.worksheet.Cells[row, col_need] as Excel.Range).Text;
                                    if (Convert.ToString(n_cant_item) == "")
                                        continue;
                                    //MessageBox.Show("Cant item: " + n_cant_item);
                                    quantity = Convert.ToInt32(n_cant_item);
                                }
                                catch
                                {
                                    MessageBox.Show("Hay un dato de cantidad no numérico en la hoja " + objxls.worksheet.Name + " Celda [" + row + "|" + col_need + "], se colocó como valor cantidad 1");
                                    quantity = 1;

                                }
                                quantity *= countaux;
                                straux = "";
                                try
                                {
                                    for (col = col_desc; col <= col_codefab; col++)
                                    {
                                        var str_data = (objxls.worksheet.Cells[row, col] as Excel.Range).Text ?? string.Empty;
                                        straux += str_data.ToString().Replace(';', ',') + ";";
                                    }
                                    if (!l_data.ContainsKey(straux))
                                    {
                                        l_data.Add(straux, quantity);
                                    }
                                    else
                                    {
                                        quantity += l_data[straux];
                                        l_data[straux] = quantity;
                                    }

                                    //Responsable
                                    var str_resp = (objxls.worksheet.Cells[row, col_resp] as Excel.Range).Text ?? string.Empty;
                                    if (!l_resp.ContainsKey(straux))
                                    {
                                        l_resp.Add(straux, str_resp.ToString());
                                    }
                                    else if (l_resp[straux] == "")
                                    {
                                        l_resp[straux] = str_resp.ToString();
                                    }
                                    else
                                    {
                                    }
                                }
                                catch
                                {
                                    this.st_label.Text = "Ocurrió un error al leer una fila de materiales en la Hoja " + objxls.worksheet.Name + " Celda [" + row + "|" + col_desc + "], se colocó como valor cantidad 1";
                                    this.mensaje.Update();
                                    MessageBox.Show(this.st_label.Text);
                                    objxls.ShowExcel();
                                    objxls.Dispose();
                                    objxls = null;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                this.st_label.Text = "Error al intentar obtener datos de hojas";
                this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
                objxls.ShowExcel();
                objxls.Dispose();
                objxls = null;
                return;
            }

            this.st_label.Text = "Conteo finalizado, completando hoja de totales...";
            this.mensaje.Update();

            try
            {
                Excel.Range c1 = null, c2 = null;
                if (objxls.SelectSheet("Total"))
                {
                    c1 = (Excel.Range)objxls.worksheet.Cells[2, 1];
                    c2 = (Excel.Range)objxls.worksheet.Cells[1000, 9];
                    //objxls.range = (Excel.Range)objxls.worksheet.get_Range("A2", "I1000");
                    try
                    {
                        objxls.range = (Excel.Range)objxls.worksheet.get_Range(c1, c2);
                        objxls.range.ClearContents();
                    }
                    catch
                    {
                        objxls.range = (Excel.Range)objxls.worksheet.Range[c1, c2];
                        objxls.range.ClearContents();
                    }
                    //objxls.range = (Excel.Range)objxls.worksheet.get_Range("K2", "M1000");
                    c1 = (Excel.Range)objxls.worksheet.Cells[2, 11];
                    c2 = (Excel.Range)objxls.worksheet.Cells[1000, 13];
                    try
                    {
                        objxls.range = (Excel.Range)objxls.worksheet.get_Range(c1, c2);
                        objxls.range.ClearContents();
                    }
                    catch
                    {
                        objxls.range = (Excel.Range)objxls.worksheet.Range[c1, c2];
                        objxls.range.ClearContents();
                    }
                }
            }
            catch
            {
                this.st_label.Text = "Error al intentar borrar los datos antiguos de la hoja de Total";
                this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
                objxls.ShowExcel();
                objxls.Dispose();
                objxls = null;
                return;
            }

            //while ((objxls.worksheet.Cells[4, 1] as Excel.Range).Text.ToString() != string.Empty)
            //{
            //    (objxls.worksheet.Cells[4, 1] as Excel.Range).EntireRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
            //}
            long l_row = 2;
            int counter = 1;
            List<string> l_list = new List<string>();
            foreach (var item in l_data.Keys)
            {
                string s_aux = item;
                l_list.Add(s_aux);
            }
            try
            {
                foreach (var item in l_list.OrderBy(d => d))
                {
                    string s_aux = item;
                    //objxls.WriteValue(l_row, col_saldo, "=RC[-1]-RC[-2]");
                    try
                    {
                        objxls.range = objxls.worksheet.get_Range("A" + l_row.ToString() + "", "N" + l_row.ToString() + "");
                    }
                    catch (Exception)
                    {
                        objxls.range = objxls.worksheet.Range["A" + l_row.ToString() + "", "N" + l_row.ToString() + ""];
                    }
                    objxls.range.Font.Size = 9;

                    //objxls.range.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                    //objxls.range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    //objxls.range.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                    //objxls.range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    //objxls.range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                    objxls.WriteValue(l_row, col_item, counter.ToString());
                    objxls.WriteValue(l_row, col_desc, s_aux);
                    objxls.WriteValue(l_row, col_need_total, l_data[s_aux].ToString());
                    objxls.WriteValue(l_row, col_build, "0");
                    objxls.WriteValue(l_row, col_resp, l_resp[s_aux].ToString());

                    //objxls.range = objxls.worksheet.get_Range("A" + l_row.ToString() + "", "A" + l_row.ToString() + "");
                    //objxls.range.Formula = objxls.range.Value;
                    //objxls.range = objxls.worksheet.get_Range("H" + l_row.ToString() + "", "J" + l_row.ToString() + "");
                    //objxls.range.Formula = objxls.range.Value;
                    //objxls.range = objxls.worksheet.get_Range("M" + l_row.ToString() + "", "N" + l_row.ToString() + "");
                    //objxls.range.Formula = objxls.range.Value;

                    l_row++;
                    counter++;

                }
            }
            catch
            {
                this.st_label.Text = "Error al completar la hoja de Total";
                this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
                objxls.Dispose();
                objxls = null;
                return;
            }

            l_row--;
            l_list = null;
            l_data = null;

            try
            {
                objxls.worksheet.PageSetup.PrintArea = "$A$1:$N$" + l_row.ToString() + "";
                this.st_label.Text = "Guardando archivo...";
                this.mensaje.Update();
                objxls.workbook.RefreshAll();
                objxls.workbook.Save();
                objxls.SelectSheet("Referencia");
                objxls.SelectSheet("Total");
            }
            catch
            {
                this.st_label.Text = "Error al intentar guardar el archivo";
                this.mensaje.Update();
                MessageBox.Show(this.st_label.Text);
                objxls.ShowExcel();
                objxls.Dispose();
                objxls = null;
                return;
            }
            this.st_label.Text = "Conteo completado";
            this.mensaje.Update();
            MessageBox.Show(this.st_label.Text);
            objxls.ShowExcel();
            objxls.Dispose();
            objxls = null;
        }

        private void tb_path_TextChanged(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(this.tb_path.Text))
                this.tb_path.BackColor = System.Drawing.SystemColors.Window;
            else
                this.tb_path.BackColor = System.Drawing.Color.IndianRed;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.st_label.Text = "";
            this.mensaje.Update();

            //string excelfilepath = "C:\\Users\\JZ4874\\Documents\\HE Desarrollo - Repo\\HE_Des\\021 - Migración E3.2021 a DSE3.2023\\Generacion de BOM\\Herramienta Silvonei\\Empty_BillOfMaterial.xlsm";
            //string excelfilepath = "C:\\Users\\JZ4874\\Documents\\HE Desarrollo - Repo\\HE_Des\\021 - Migración E3.2021 a DSE3.2023\\Generacion de BOM\\Herramienta Silvonei\\Empty_BillOfMaterial.xlsm";

            //var route = Request.Path.Value;
            //var myRoute = Url.RouteUrl(RouteData.Values);
            string route = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);

            //MessageBox.Show("Route is: " + route);
            ////data.Split(new string[] { "xx" }, StringSplitOptions.None);
            //MessageBox.Show("Routes are: " + route.Split(new string[] { "bin" }, StringSplitOptions.None)[0] + " |Separacion| " + route.Split(new string[] { "bin" }, StringSplitOptions.None)[1]);

            ////MessageBox.Show("Route to new doc is: " + route + "\\Empty_BillOfMaterial.xlsm");

            ////MessageBox.Show("Route is: " + route.Split(new string[] { "bin" }, StringSplitOptions.None)[0] + @"\" + "Empty_BillOfMaterial.xlsm");
            //MessageBox.Show("Route is: " + route.Split(new string[] { "bin" }, StringSplitOptions.None)[0] + "Empty_BillOfMaterial.xlsm");

            //string excelfilepath = route.Split(new string[] { "bin" }, StringSplitOptions.None)[0] + @"\" + "Empty_BillOfMaterial.xlsm";
            string excelfilepath = route.Split(new string[] { "bin" }, StringSplitOptions.None)[0] + "Empty_BillOfMaterial.xlsm";

            this.Hide();
            var formAddShts = new AddAdditionalShts();

            formAddShts.Closed += (s, args) =>
            {
                this.Show();

                string[] values = { };

                if (formAddShts.DocValues != "") {
                    values = formAddShts.DocValues.Split('\n');
                }

                for (int i = 0; i < values.Length; i++)
                {
                    System.Drawing.Bitmap icon = Properties.Resources.check;
                    icon = new Bitmap(icon, new Size(24, 24));
                    object[] tmp_data = new object[] {
                        values[i],
                        excelfilepath,
                        1,
                        icon};
                    this.dataGridView1.Rows.Add(tmp_data);
                    tmp_data = null;
                    icon = null;
                    this.st_label.Text = "Documento agregado a la lista";
                    this.mensaje.Update();
                }
            };

            formAddShts.Show();
        }
    }
}
