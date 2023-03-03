# WebAPI

## Background
WebAPI is an solution on an assignment from the Accelerated Larning course in Fullstack .NET developer (Noroff). WebAPI is an ASP.Net application written in C# and utilize Entity Framework Core by code first. 
## Description

![database diagram](https://user-images.githubusercontent.com/15190773/222738786-6d6305d2-f0fc-4d39-8376-fdea42e3fa3e.PNG)

## Running Project


## Status of the Project
Only one week for the project and should be completed the 17. February 2023.

#  GIT Convention
This project use the [conventional commits 1.0.0](https://www.conventionalcommits.org/en/v1.0.0/) and [branch naming](https://dev.to/couchcamote/git-branching-name-convention-cch).
## Naming Branches
There are two permanent branches, Master and Test. The Master branch is the production branch, and the Test branch is the temporary branch for testing an temporary branch in the master branch.

if the Test branch works correctly after merge an temporary branch in, can the Test branch make an merge request into the master branch.

### Temporary branches
Temporary branches is to be branched out from the master branch and to be working on some content for the application. Temporary branches naming should be structured as \<category>/description-in-kebab-case>.

The categories:
- features
- docs
- bugfix
- hotfix
- test

## Git Commits
This means the commit message should be structured as follows:

    <type>: <description>

where \<types> used can be:
 - fix (the correlates with PATCH in Semantic versioning)
 - feat (the correlates with MINOR in Semantic versioning)
 - docs
 - style
 - refactor
 - test

In addition, there is possible to apply the "!" as suffix of the type to indicate breaking API changes (the correlates with MAJOR in Semantic versioning).

The \<description> should be meaningful in such a way that it solely can explain the commit and the commit should only cover small additions.
