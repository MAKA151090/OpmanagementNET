using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HealthCare.Models;

namespace HealthCare.Controllers;

public class FormsController : Controller
{
  public IActionResult BasicInputs() => View();
  public IActionResult InputGroups() => View();
}
