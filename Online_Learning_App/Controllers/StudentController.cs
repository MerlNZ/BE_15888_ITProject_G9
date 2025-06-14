﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Learning_App.Infrastructure;
using Online_Learning_APP.Application.DTO;
using Online_Learning_APP.Application.Interfaces;
using Online_Learning_APP.Application.DTO;


namespace Online_Learning_App_Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut("update-class")]
        public async Task<IActionResult> UpdateStudentClass([FromBody] UpdateStudentClassDto dto)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.UserName == dto.UserName);

            if (student == null)
                return NotFound("Student not found");

            student.ClassLevel = dto.ClassLevel;
            student.ClassGroupId = dto.ClassGroupId;

            await _context.SaveChangesAsync();

            return Ok("Student updated successfully.");
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetStudent(string username)
        {
            var student = await _context.Students
                .Include(s => s.ClassGroup)
                .FirstOrDefaultAsync(s => s.UserName == username);

            if (student == null)
                return NotFound("Student not found");

            return Ok(new
            {
                student.UserName,
                student.Email,
                student.ClassLevel,
                student.ClassGroupId,
                ClassGroupName = student.ClassGroup?.ClassName
            });
        }

        [HttpGet("{username}/activities-with-submission")]
        public async Task<IActionResult> GetStudentActivitiesWithSubmissions(string username)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.UserName == username);

            if (student == null) return NotFound("Student not found.");

             var activitiesStudent = await _context.ClassGroupSubjectStudentActivity.Include(a=>a.Activity)
                .Where(a => a.StudentId == student.Id)
                .ToListAsync();

            var submissions = await _context.Submissions
                .Where(s => s.StudentId == student.Id)
                .ToListAsync();

            var result = activitiesStudent.Select(a =>
            {
                var submission = submissions.FirstOrDefault(s => s.ActivityId == a.ActivityId);

                return new StudentActivityWithSubmissionDto
                {
                    ActivityId = a.ActivityId,
                    Title = a.Activity.Title,
                    Description = a.Activity.Description,
                    DueDate = a.Activity.DueDate,
                   // PdfUrl = a.Activity.PdfUrl,
                    teacherPdfUrl= a.Activity.PdfUrl,
                     PdfUrl = a.pdfUrl,
                    IsSubmitted = submission != null,
                    SubmissionUrl = submission?.PdfUrl,
                    SubmissionDate = submission?.SubmissionDate,
                    Feedback = submission?.Feedback,
                    Grade = submission?.Grade,
                    StudentComment = submission?.StudentComment

                };
            }).ToList();

            return Ok(result);
        }

        [HttpGet("/pendingsubmission")]
        public async Task<IActionResult> PendingSubmissions()
        {

            var activitiesStudent = await _context.ClassGroupSubjectStudentActivity.Include(a => a.Activity)
               // .Where(a => a.StudentId == student.Id)
                .ToListAsync();

            var submissions = await _context.Submissions
               // .Where(s => !string.IsNullOrEmpty( s.Feedback))
                .ToListAsync();

            var result = activitiesStudent.Select(a =>
            {
                var submission = submissions.FirstOrDefault(s => s.ActivityId == a.ActivityId);

                return new StudentActivityWithSubmissionDto
                {
                    ActivityId = a.ActivityId,
                    Title = a.Activity.Title,
                    Description = a.Activity.Description,
                    DueDate = a.Activity.DueDate,
                    PdfUrl = a.pdfUrl,
                    IsSubmitted = submission != null,
                    SubmissionUrl = submission?.PdfUrl,
                    SubmissionDate = submission?.SubmissionDate,
                    Feedback = submission?.Feedback,
                    Grade = submission?.Grade,
                    StudentComment = submission?.StudentComment

                };
            }).ToList();
            //var finalresult= result.Where(a=> a.PdfUrl==null).ToList();
            return Ok(result);
        }


        [HttpGet("get-student-id/{username}")]
        public async Task<IActionResult> GetStudentIdByUsername(string username)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.UserName == username);

            if (student == null)
                return NotFound("Student not found.");

            return Ok(new { studentId = student.Id });
        }

        [HttpGet("get-student-id-by-userID/{userId}")]
        public async Task<IActionResult> GetStudentIdByUserId(Guid userId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.UserId == userId);

            if (student == null)
                return NotFound("Student not found for this user.");

            return Ok(new { studentId = student.Id });
        }

        [HttpGet("profile/{studentId}")]
        public async Task<ActionResult<StudentProfileDto>> GetStudentProfile(Guid studentId)
        {
            var student = await _context.Students
                .Include(s => s.User)
                .Where(s => s.Id == studentId)
                .Select(s => new StudentProfileDto
                {
                    UserId = s.User.Id,
                    FirstName = s.User.FirstName,
                    LastName = s.User.LastName,
                    Email = s.User.Email
                })
                .FirstOrDefaultAsync();

            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }

        [HttpGet("student/summary/{username}")]
        public async Task<IActionResult> GetStudentSubmissionSummary(string username)
        {
            var student = await _context.Students
                .Include(s => s.ClassGroup)
                .FirstOrDefaultAsync(s => s.UserName == username);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            var classGroupId = student.ClassGroupId;

            // Get all activities assigned to this class group
            var totalActivities = await _context.Activities
                .Where(a => a.ClassGroupId == classGroupId)
                .CountAsync();

            // Get all submissions made by the student
            var submissions = await _context.Submissions
                .Where(s => s.StudentId == student.Id)
                .ToListAsync();

            var totalSubmissions = submissions.Count;
            var gradedSubmissions = submissions.Count(s => s.Grade > 0);
            var ungradedSubmissions = totalSubmissions - gradedSubmissions;

            var result = new
            {
                TotalActivities = totalActivities,
                TotalSubmissions = totalSubmissions,
                GradedSubmissions = gradedSubmissions,
                UngradedSubmissions = ungradedSubmissions
            };

            return Ok(result);
        }

    }

}