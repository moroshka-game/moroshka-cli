using Moroshka.Cli;
using Spectre.Console.Cli;

var app = new CommandApp();

app.Configure(config =>
{
	config.SetApplicationName("moroshka");

	config.AddCommand<InitCommand>("init")
		.WithDescription("Initialize a new project");

	config.AddCommand<LsCommand>("ls")
		.WithDescription("Display the list of Moroshka modules");

	config.AddBranch("clone", cloneCommand =>
	{
		cloneCommand.SetDescription("Clone a Moroshka modules");
		cloneCommand.SetDefaultCommand<CloneCommand>();

		cloneCommand.AddCommand<CloneAllCommand>("all")
			.WithDescription("Clone all Moroshka modules");

		cloneCommand.AddCommand<CloneCommand>("indexes")
			.WithDescription("Clone Moroshka modules by indexes");
	});

	config.AddBranch("new", newCommand =>
	{
		newCommand.SetDescription("Create a new Moroshka module");
		newCommand.SetDefaultCommand<NewUpmProjectCommand>();

		newCommand.AddCommand<NewUpmCommand>("upm")
			.WithDescription("Create a new Moroshka module upm");

		newCommand.AddCommand<NewUpmProjectCommand>("upm-project")
			.WithDescription("Create a new Moroshka module upm project");
	});
});

app.Run(args);
