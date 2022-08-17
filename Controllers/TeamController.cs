using System;
using System.Web.Mvc;
using System.Web.Routing;
using Farhad_Apro.Models;
using Farhad_Apro.Repository.DB;
using Farhad_Apro.Repository.Manager;
using Farhad_Apro.ViewModel;

namespace Farhad_Apro.Controllers
{
    public class TeamController : Controller
    {
        private readonly TeamDetailsManager _teamDetailsManager;
        private readonly TeamMembersManager _teamMembersManager;

        public TeamController()
        {
            var db = new ApplicationDbContext();
            _teamDetailsManager = new TeamDetailsManager(db);
            _teamMembersManager = new TeamMembersManager(db);
        }

        [HttpGet]
        public ActionResult TeamStatus()
        {
            var list = _teamDetailsManager.GetAll();
            return View(list);
        }

        [HttpPost]
        public string StatusUpdate(int id, string type)
        {
            var team = _teamDetailsManager.GetById(id);
          
            switch (type)
            {
                case "Manager":
                    switch (team.ApprovalStatusFromManager)
                    {
                        case Enum.TeamStatus.Approved:
                            team.ApprovalStatusFromManager = Enum.TeamStatus.NotApproved;
                            _teamDetailsManager.Update(team);
                            return "Not Approved";
                        case Enum.TeamStatus.NotApproved:
                            team.ApprovalStatusFromManager = Enum.TeamStatus.NoActionTaken;
                            _teamDetailsManager.Update(team);
                            return "No Action";
                        default:
                            team.ApprovalStatusFromManager = Enum.TeamStatus.Approved;
                            _teamDetailsManager.Update(team);
                            return "Approved";
                    }
                case "Director":
                    switch (team.ApprovalStatusFromDirector)
                    {
                        case Enum.TeamStatus.Approved:
                            team.ApprovalStatusFromDirector = Enum.TeamStatus.NotApproved;
                            _teamDetailsManager.Update(team);
                            return "Not Approved";
                        case Enum.TeamStatus.NotApproved:
                            team.ApprovalStatusFromDirector = Enum.TeamStatus.NoActionTaken;
                            _teamDetailsManager.Update(team);
                            return "No Action";
                        default:
                            team.ApprovalStatusFromDirector = Enum.TeamStatus.Approved;
                            _teamDetailsManager.Update(team);
                            return "Approved";
                    }
                default:
                    return "Not Updated";
            }
        }

        [HttpGet]
        public ActionResult NewTeam()
        {
            ViewBag.SuccessMessage = TempData["Success"];
            ViewBag.ErrorMessage = TempData["Error"];
            return View();
        }
        
        [HttpGet]
        public ActionResult AddTeamMembers()
        {
            return PartialView("_AddTeamMembers");
        }

        [HttpPost]
        public ActionResult Add(TeamInfoVm teamInfo)
        {
            try
            {
                var teamDetails = new TeamDetails
                {
                    TeamName = teamInfo.TeamName, 
                    Description = teamInfo.Description,
                    IsActive = true
                };
                if (_teamDetailsManager.Add(teamDetails))
                {
                    var teamMembers = teamInfo.Details;
                    teamMembers.ForEach(x => x.TeamDetailsId = teamDetails.Id);
                    _teamMembersManager.Add(teamMembers);
                }

                TempData["Success"] = "New team has been saved";
            }
            catch (Exception)
            {
                TempData["Error"] = "Team saving error. Please try again";
            }

            return RedirectToAction("NewTeam");
        }
        
        [HttpPost]
        public string DeleteTeam(int id)
        {
            // not deleted from db
            var team = _teamDetailsManager.GetById(id);
            if (team == null) return "Team deletion failed";
            team.IsActive = false;
            return _teamDetailsManager.Update(team) ? "Team deleted successfully" : "Team deletion failed";
        }
    }
}