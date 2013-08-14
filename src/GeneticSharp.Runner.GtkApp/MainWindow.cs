using System;
using System.Globalization;
using Gdk;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Extensions.Tsp;
using Gtk;
using HelperSharp;

public partial class MainWindow: Gtk.Window
{	
	#region Fields
	private Population m_population;
	private TspFitness m_fitness;
	private Gdk.GC m_gc;
	private Pango.Layout m_layout;
	private Pixmap m_buffer;
    private DateTime m_currentGenerationsBeginDateTime;
    private TimeSpan? m_currentGenerationsTimeSpend;
	#endregion

	#region Constructors
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		SetDefaultSize(800, 600);

		DeleteEvent+=delegate {Application.Quit(); };
		btnGenerateCities.Clicked += delegate { GenerateCities(); };
        btnRunGeneration.Clicked += delegate { RunGenerations(1); };
        btnRunGenerations.Clicked += delegate { RunGenerations(10000); };
	
		m_gc = new Gdk.GC(drawingArea.GdkWindow);
		m_gc.RgbFgColor = new Gdk.Color(255,50,50);
		m_gc.RgbBgColor = new Gdk.Color(255, 255, 255);
		m_gc.Background =  new Gdk.Color(255, 255, 255);
		m_gc.SetLineAttributes(1, LineStyle.OnOffDash, CapStyle.Projecting, JoinStyle.Round);
	
		m_layout = new Pango.Layout(this.PangoContext);
		m_layout.Alignment = Pango.Alignment.Center;
		m_layout.FontDescription = Pango.FontDescription.FromString("Arial 16");	

		hslNumberOfCities.ValueChanged += delegate {
			GenerateCities();
		};



		drawingArea.ConfigureEvent += delegate {
			ResetBuffer ();
			DrawCities ();
			DrawBuffer ();
		};

		ShowAll();
	}
	#endregion

	#region Methods
    private void RunGenerations(int generations)
    {
        m_currentGenerationsBeginDateTime = DateTime.Now;
        m_population.RunGenerations(generations);  
		var x = m_population.BestChromosome;
    }

	private void GenerateCities()
	{
		if (m_population != null) {
			m_population.GenerationRan -= HandleGenerationRan;
            m_currentGenerationsTimeSpend = null;
		}        

		int numberOfCities = Convert.ToInt32(hslNumberOfCities.Value - (hslNumberOfCities.Value % 2));
		hslNumberOfCities.Value = numberOfCities;
		var selection = new EliteSelection();
		var crossover = new OrderedCrossover();
        //var mutation = new TworsMutation();
		var mutation = new ReverseSequenceMutation ();
		var chromosome = new TspChromosome(numberOfCities);
		m_fitness = new TspFitness (numberOfCities, 50, drawingArea.Allocation.Width -50, 50, drawingArea.Allocation.Height - 50);

		m_population = new Population(
			Convert.ToInt32(hslMinPopulationSize.Value),
			Convert.ToInt32(hslMaxPopulationSize.Value),
			chromosome,
			m_fitness,
			selection, crossover, mutation);

		m_population.GenerationRan += HandleGenerationRan; 
	
		DrawCities ();
		DrawBuffer ();
	}

	
	void HandleGenerationRan (object sender, EventArgs e)
	{
        m_currentGenerationsTimeSpend = DateTime.Now - m_currentGenerationsBeginDateTime;
		UpdateMap ();
	}

	private void UpdateMap()
	{
		DrawCities ();

		if (m_population.CurrentGeneration != null) {
			var genes = m_population.BestChromosome.GetGenes ();

			for (int i = 0; i < genes.Length; i += 2) {
				var cityOneIndex = Convert.ToInt32 (genes [i].Value);
				var cityTwoIndex = Convert.ToInt32 (genes [i + 1].Value);
				var cityOne = m_fitness.Cities [cityOneIndex];
				var cityTwo = m_fitness.Cities [cityTwoIndex];

				if (i > 0) {
					var previousCity = m_fitness.Cities [Convert.ToInt32 (genes [i - 1].Value)];
					m_buffer.DrawLine (m_gc, previousCity.X, previousCity.Y, cityOne.X, cityOne.Y);
				}

				m_buffer.DrawLine (m_gc, cityOne.X, cityOne.Y, cityTwo.X, cityTwo.Y);


				m_layout.SetMarkup ("<span color='black'>{0}</span>".With (i));
				m_buffer.DrawLayout (m_gc, cityOne.X, cityOne.Y, m_layout);

				m_layout.SetMarkup ("<span color='black'>{0}</span>".With (i + 1));
				m_buffer.DrawLayout (m_gc, cityTwo.X, cityTwo.Y, m_layout);
			}

			var lastCity = m_fitness.Cities [Convert.ToInt32 (genes [genes.Length - 1].Value)];
			var firstCity = m_fitness.Cities [Convert.ToInt32 (genes [0].Value)];
			m_buffer.DrawLine (m_gc, lastCity.X, lastCity.Y, firstCity.X, firstCity.Y);
		}

        WriteText(0, 0, "Generation: {0}", m_population.Generations.Count);
        WriteText(0, 20, "Distance: {0:n2}", ((TspChromosome) m_population.BestChromosome).Distance);
        WriteText(0, 40, "Time: {0}", m_currentGenerationsTimeSpend);

		DrawBuffer ();
	}

    private void WriteText(int x, int y, string text, params object[] args)
    {
        m_layout.SetMarkup("<span color='gray'>{0}</span>".With(String.Format(CultureInfo.InvariantCulture, text, args)));
        m_buffer.DrawLayout(m_gc, x, y, m_layout);
    }

	private void ResetBuffer()
	{
		m_buffer = new Pixmap (drawingArea.GdkWindow, drawingArea.Allocation.Width, drawingArea.Allocation.Height);
	}

	private void DrawCities()
	{
		if (m_fitness == null) {
			GenerateCities ();
		}

		m_buffer.DrawRectangle(drawingArea.Style.WhiteGC, true, 0, 0, drawingArea.Allocation.Width, drawingArea.Allocation.Height);

		foreach (var c in m_fitness.Cities)
		{
			m_buffer.DrawRectangle(m_gc, true, c.X - 2, c.Y - 2, 4, 4);
		}
	}

	private void DrawBuffer()
	{
		drawingArea.GdkWindow.DrawDrawable (m_gc, m_buffer, 0, 0, 0, 0, drawingArea.Allocation.Width, drawingArea.Allocation.Height);
	}

	protected override bool OnConfigureEvent (EventConfigure evnt)
	{
		ResetBuffer ();
		DrawCities ();
		DrawBuffer ();

		return base.OnConfigureEvent (evnt);
	}
	

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}	
	#endregion
}
