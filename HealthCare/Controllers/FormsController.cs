using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;

namespace HealthCare.Controllers;

[Authorize]
public class FormsController : Controller
{
  
  public IActionResult BasicInputs() => View();
  public IActionResult InputGroups() => View();
}
