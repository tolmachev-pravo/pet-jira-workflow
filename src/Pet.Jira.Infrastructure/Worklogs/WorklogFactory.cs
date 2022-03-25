﻿using Atlassian.Jira;
using Pet.Jira.Domain.Models.Worklogs;
using Pet.Jira.Infrastructure.Jira;
using System;

namespace Pet.Jira.Infrastructure.Worklogs
{
    public class WorklogFactory
    {
        private readonly JiraLinkGenerator _linkGenerator;

        public WorklogFactory(
            JiraLinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public T Create<T>(
            DateTime startedAt,
            DateTime completedAt,
            Issue issue)
            where T: EstimatedWorklog, new()
        {
            return new T
            {
                StartedAt = startedAt,
                CompletedAt = completedAt,
                Issue = new Domain.Models.Issues.Issue
                {
                    Key = issue.Key.Value,
                    Summary = issue.Summary,
                    Link = _linkGenerator.Generate(issue.Key.Value)
                }
            };
        }
    }
}
