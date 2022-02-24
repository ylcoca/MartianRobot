// See https://aka.ms/new-console-template for more information

using Entities;
using MartianRobot;
using MartianRobot.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



var services = new ServiceCollection();
services.AddSingleton<IManageRobotService, ManageRobotService>();
services.AddSingleton<IFile, FileManagement>();
services.AddSingleton<RobotMovement>();
var serviceProvider = services.BuildServiceProvider();
var robotAppService = serviceProvider.GetService<RobotMovement>();

robotAppService.ReadFile();
robotAppService.GetRobotsMovement();


 Console.ReadLine();



