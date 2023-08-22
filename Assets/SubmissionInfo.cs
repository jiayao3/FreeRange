
// This class contains metadata for your submission. It plugs into some of our
// grading tools to extract your game/team details. Ensure all Gradescope tests
// pass when submitting, as these do some basic checks of this file.
public static class SubmissionInfo
{
    // TASK: Fill out all team + team member details below by replacing the
    // content of the strings. Also ensure you read the specification carefully
    // for extra details related to use of this file.

    // URL to your group's project 2 repository on GitHub.
    public static readonly string RepoURL = "https://github.com/COMP30019/project-2-console-writeline-give-us-h1";
    
    // Come up with a team name below (plain text, no more than 50 chars).
    public static readonly string TeamName = "Console.WriteLine('give us h1')";
    
    // List every team member below. Ensure student names/emails match official
    // UniMelb records exactly (e.g. avoid nicknames or aliases).
    public static readonly TeamMember[] Team = new[]
    {
        new TeamMember("Caitlyn Allan", "cpallan@student.unimelb.edu.au"),
        new TeamMember("Jiayao Wu", "jiayao3@student.unimelb.edu.au"),
        new TeamMember("Brandon Widjaja", "bwwid@student.unimelb.edu.au"),
        new TeamMember("Hanlin Zhu", "hanzhu1@student.unimelb.edu.au"), 
    };

    // This may be a "working title" to begin with, but ensure it is final by
    // the video milestone deadline (plain text, no more than 50 chars).
    public static readonly string GameName = "Free Range";

    // Write a brief blurb of your game, no more than 200 words. Again, ensure
    // this is final by the video milestone deadline.
    public static readonly string GameBlurb = 
@"Free Range! One day a pair of chickens, you and Range, are taking a nice 
stroll when suddenly you turn around and Range is no longer with you. He has 
been taken by a snake! Embark on a quest to track down the snake and rescue 
Range with help from the variety of eggs you collect along the way. Will you 
successfully free Range or will you doom all to be dinner for the snake?
";
    
    // By the gameplay video milestone deadline this should be a direct link
    // to a YouTube video upload containing your video. Ensure "Made for kids"
    // is turned off in the video settings. 
    public static readonly string GameplayVideo = "https://www.youtube.com/watch?v=drr7x4rxfxk";
    
    // No more info to fill out!
    // Please don't modify anything below here.
    public readonly struct TeamMember
    {
        public TeamMember(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; }
        public string Email { get; }
    }
}
