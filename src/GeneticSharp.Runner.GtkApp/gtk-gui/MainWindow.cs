
// This file has been generated by the GUI designer. Do not modify.
public partial class MainWindow
{
	private global::Gtk.HBox hbox1;
	private global::Gtk.DrawingArea drawingArea;
	private global::Gtk.VBox vbox1;
	private global::Gtk.HScale hslNumberOfCities;
	private global::Gtk.Button btnGenerateCities;
	private global::Gtk.HSeparator hseparator1;
	private global::Gtk.Label label1;
	private global::Gtk.HScale hslMinPopulationSize;
	private global::Gtk.HScale hslMaxPopulationSize;
	private global::Gtk.HSeparator hseparator2;
	private global::Gtk.Button btnRunGeneration;
	private global::Gtk.Button btnRunGenerations;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.DefaultWidth = 640;
		this.DefaultHeight = 480;
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Spacing = 10;
		this.hbox1.BorderWidth = ((uint)(10));
		// Container child hbox1.Gtk.Box+BoxChild
		this.drawingArea = new global::Gtk.DrawingArea ();
		this.drawingArea.Name = "drawingArea";
		this.hbox1.Add (this.drawingArea);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.drawingArea]));
		w1.Position = 0;
		w1.Padding = ((uint)(1));
		// Container child hbox1.Gtk.Box+BoxChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hslNumberOfCities = new global::Gtk.HScale (null);
		this.hslNumberOfCities.CanFocus = true;
		this.hslNumberOfCities.Name = "hslNumberOfCities";
		this.hslNumberOfCities.Adjustment.Lower = 2;
		this.hslNumberOfCities.Adjustment.Upper = 102;
		this.hslNumberOfCities.Adjustment.PageIncrement = 10;
		this.hslNumberOfCities.Adjustment.PageSize = 2;
		this.hslNumberOfCities.Adjustment.StepIncrement = 2;
		this.hslNumberOfCities.Adjustment.Value = 10;
		this.hslNumberOfCities.DrawValue = true;
		this.hslNumberOfCities.Digits = 0;
		this.hslNumberOfCities.ValuePos = ((global::Gtk.PositionType)(2));
		this.vbox1.Add (this.hslNumberOfCities);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hslNumberOfCities]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.btnGenerateCities = new global::Gtk.Button ();
		this.btnGenerateCities.CanFocus = true;
		this.btnGenerateCities.Name = "btnGenerateCities";
		this.btnGenerateCities.UseUnderline = true;
		this.btnGenerateCities.Label = global::Mono.Unix.Catalog.GetString ("Generate _Cities");
		this.vbox1.Add (this.btnGenerateCities);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.btnGenerateCities]));
		w3.Position = 1;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hseparator1 = new global::Gtk.HSeparator ();
		this.hseparator1.Name = "hseparator1";
		this.vbox1.Add (this.hseparator1);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hseparator1]));
		w4.Position = 2;
		w4.Expand = false;
		w4.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Population size");
		this.vbox1.Add (this.label1);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.label1]));
		w5.Position = 3;
		w5.Expand = false;
		w5.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hslMinPopulationSize = new global::Gtk.HScale (null);
		this.hslMinPopulationSize.CanFocus = true;
		this.hslMinPopulationSize.Name = "hslMinPopulationSize";
		this.hslMinPopulationSize.Adjustment.Lower = 2;
		this.hslMinPopulationSize.Adjustment.Upper = 1002;
		this.hslMinPopulationSize.Adjustment.PageIncrement = 10;
		this.hslMinPopulationSize.Adjustment.PageSize = 2;
		this.hslMinPopulationSize.Adjustment.StepIncrement = 1;
		this.hslMinPopulationSize.Adjustment.Value = 40;
		this.hslMinPopulationSize.DrawValue = true;
		this.hslMinPopulationSize.Digits = 0;
		this.hslMinPopulationSize.ValuePos = ((global::Gtk.PositionType)(2));
		this.vbox1.Add (this.hslMinPopulationSize);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hslMinPopulationSize]));
		w6.Position = 4;
		w6.Expand = false;
		w6.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hslMaxPopulationSize = new global::Gtk.HScale (null);
		this.hslMaxPopulationSize.CanFocus = true;
		this.hslMaxPopulationSize.Name = "hslMaxPopulationSize";
		this.hslMaxPopulationSize.Adjustment.Lower = 2;
		this.hslMaxPopulationSize.Adjustment.Upper = 1002;
		this.hslMaxPopulationSize.Adjustment.PageIncrement = 10;
		this.hslMaxPopulationSize.Adjustment.PageSize = 2;
		this.hslMaxPopulationSize.Adjustment.StepIncrement = 1;
		this.hslMaxPopulationSize.Adjustment.Value = 50;
		this.hslMaxPopulationSize.DrawValue = true;
		this.hslMaxPopulationSize.Digits = 0;
		this.hslMaxPopulationSize.ValuePos = ((global::Gtk.PositionType)(2));
		this.vbox1.Add (this.hslMaxPopulationSize);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hslMaxPopulationSize]));
		w7.Position = 5;
		w7.Expand = false;
		w7.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hseparator2 = new global::Gtk.HSeparator ();
		this.hseparator2.Name = "hseparator2";
		this.vbox1.Add (this.hseparator2);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hseparator2]));
		w8.Position = 6;
		w8.Expand = false;
		w8.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.btnRunGeneration = new global::Gtk.Button ();
		this.btnRunGeneration.CanFocus = true;
		this.btnRunGeneration.Name = "btnRunGeneration";
		this.btnRunGeneration.UseUnderline = true;
		this.btnRunGeneration.Label = global::Mono.Unix.Catalog.GetString ("_Run generation");
		this.vbox1.Add (this.btnRunGeneration);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.btnRunGeneration]));
		w9.Position = 7;
		w9.Expand = false;
		w9.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.btnRunGenerations = new global::Gtk.Button ();
		this.btnRunGenerations.CanFocus = true;
		this.btnRunGenerations.Name = "btnRunGenerations";
		this.btnRunGenerations.UseUnderline = true;
		this.btnRunGenerations.Label = global::Mono.Unix.Catalog.GetString ("Run _Generations");
		this.vbox1.Add (this.btnRunGenerations);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.btnRunGenerations]));
		w10.Position = 8;
		w10.Expand = false;
		w10.Fill = false;
		this.hbox1.Add (this.vbox1);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox1]));
		w11.Position = 1;
		w11.Expand = false;
		w11.Fill = false;
		w11.Padding = ((uint)(10));
		this.Add (this.hbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
	}
}
