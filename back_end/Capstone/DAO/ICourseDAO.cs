﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface ICourseDAO
    {
        Course SelectCourse(int CourseID);

        Course AddCourse(Course course);
    }
}
