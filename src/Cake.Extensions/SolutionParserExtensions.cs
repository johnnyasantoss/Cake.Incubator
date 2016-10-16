﻿// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/. 

namespace Cake.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cake.Common.Solution;
    using Cake.Common.Solution.Project;
    using Cake.Core.IO;

    public static class SolutionParserExtensions
    {
        public static bool IsSolutionFolder(this SolutionProject project)
        {
            return project.Type.Equals("{2150E333-8FDC-42A3-9474-1A3956D46DE8}", StringComparison.InvariantCultureIgnoreCase);
        }

        public static IEnumerable<SolutionProject> GetProjects(this SolutionParserResult projects)
        {
            return projects.Projects.Where(x => !IsSolutionFolder(x));
        }

        public static FilePath GetAssemblyFilePath(this SolutionProject solutionProject, ProjectParserResult project)
        {
            solutionProject.ThrowIfNull(nameof(solutionProject));
            project.ThrowIfNull(nameof(project));

            var assemblyFilePath = project.GetAssemblyFilePath();
            return solutionProject.Path.GetDirectory().CombineWithFilePath(assemblyFilePath);
        }
    }
}