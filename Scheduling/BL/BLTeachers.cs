﻿using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLTeachers
    {
        /// <returns>teacher list </returns>
        public static List<teacher> GetAllTeachers()
        {
            SchedulingEntities schoolEntities = new SchedulingEntities();

            return schoolEntities.teachers.ToList();
        }

        /// <summary>
        ///  updates teacher's deatails 
        /// </summary>
        /// <param name="teacher"></param> 
        public static void EditTeacher(teacher newTeacher, teacher teacher)
        {
            SchedulingEntities schoolEntities = new SchedulingEntities();

            teacher t = schoolEntities.teachers.ToList().Find(i => i.code == teacher.code);
          
            t.lastName = newTeacher.lastName;
            t.firstName = newTeacher.firstName;

            try
            {
                schoolEntities.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

        /// <summary>
        /// method adds teacher
        /// </summary>
        public static void addTeacher(teacher newTeacher)
        {
            SchedulingEntities schoolEntities = new SchedulingEntities();

          schoolEntities.teachers.Add(newTeacher);
           
            try
            {
                schoolEntities.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }
        /// <summary>
        ///  returns teacher by profession
        /// </summary>
        /// <param name="prof"></param>
        public static teacher GetMember(string prof)
        {
            SchedulingEntities schoolEntities = new SchedulingEntities();
            var r = schoolEntities.Professions.ToList();
            Profession code = r.Find(a => a.professionName == prof);
            teacher m = schoolEntities.teachers.ToList().Find(a => a.code == code.codeTeach);
            return m; 
        }
    }
}
