using System.Collections.Generic;

namespace BuzzwordService.Helpers
{
    public class BuzzwordDataStore : IBuzzwordDataStore
    {
        private static IDictionary<string, List<string>> _buzzwords = new Dictionary<string, List<string>>();

        public BuzzwordDataStore()
        {
            Initialize();
        }

        public List<string> GetByCategory(string category)
        {
            if(!CategoryExists(category)) return null;
            return _buzzwords[category];
        }

        public bool CategoryExists(string category)
        {
            return _buzzwords.ContainsKey(category);
        }

        private void Initialize()
        {
            _buzzwords.Add("education", GetEducationBuzzwords());
            _buzzwords.Add("general", GetGeneralBuzzwords());
            _buzzwords.Add("politics", GetPoliticsBuzzwords());
            _buzzwords.Add("technology", GetTechnologyBuzzwords());
        }

        private List<string> GetEducationBuzzwords()
        {
            return new List<string> {
                "Accountable talk",
                "Higher-order thinking",
                "Invested in",
                "Run like a business",
                "Student engagement",
                "Common Core",
                "Bloom's Taxonomy",
                "Differentiated instruction",
                "Digital Literacy",
                "Flipped Classroom",
                "Guided Reading",
                "Instructional Scaffolding",
                "Multiple Intelligences",
                "Project-Based Learning",
                "Adaptive Learning",
                "Brain Break",
                "Cooperative Learning"
            };
        }

        private List<string> GetGeneralBuzzwords()
        {
            return new List<string> {
                "Action this/that",
                "Alignment",
                "At the end of the day",
                "Break through the clutter",
                "Bring to the table",
                "Buzzword",
                "Clear goal",
                "Disruptive innovation",
                "Diversity",
                "Empowerment",
                "Exit strategy",
                "Face time",
                "Generation X",
                "Globalization",
                "Going forward - instead of 'in the future'",
                "Grow – as in 'grow the business'",
                "Headlights - to gain visibility into",
                "Holistic approach",
                "Impact – instead of effect as a noun",
                "Leverage – used as verb to mean magnify, multiply, augment, or increase",
                "Millennial",
                "Moving forward",
                "New normal",
                "On the runway",
                "Organic growth",
                "Outside the box",
                "Paradigm",
                "Paradigm shift",
                "Proactive",
                "Push the envelope",
                "Reach out – as in 'I'll reach out to sales to get the latest figures'",
                "Sea change",
                "Sisterhood",
                "Spin-up",
                "Strategic Communication - also known as 'Stratcom'",
                "Streamline",
                "Survival strategy",
                "Sustainability",
                "Synergy",
                "Unpack - as in 'Let me unpack that statement'",
                "Wellness",
                "Wheelhouse - as in 'That's in my wheelhouse'",
                "Win-win"
            };
        }

        private List<string> GetPoliticsBuzzwords()
        {
            return new List<string> {
                "Big society",
                "Information society",
                "Political capital",
                "Statist",
                "Stakeholder"
            };
        }

        private List<string> GetTechnologyBuzzwords()
        {
            return new List<string> {
                "4G",
                "Aggregator",
                "Agile",
                "Ajax",
                "Algorithm",
                "Benchmarking",
                "Back-end",
                "Beta",
                "Big data - larger data sets than last month",
                "Bleeding edge",
                "Blog – plus various other words that incorporate 'blog'",
                "Bring your own Device - use of personal equipment (usually mobile) in a work environment",
                "Bricks-and-clicks",
                "Clickthrough",
                "Cloud",
                "CloudOps",
                "Collaboration",
                "Content management",
                "Content Management System – also known as CMS.",
                "Convergence",
                "Cross-platform",
                "Cyber-physical Systems (CSP)",
                "Datafication",
                "Data mining - any kind of data collection or analysis, even simple statistics such as taking averages on large data sets",
                "Data science",
                "Deep dive",
                "Deep web - used interchageably with 'Dark web' even though they're not the same",
                "Design pattern",
                "DevOps",
                "Digital divide",
                "Digital Remastering",
                "Digital Rights Management – also known as DRM.",
                "Digital signage",
                "Disruptive Technologies",
                "Document management",
                "Dot-bomb",
                "____-Driven Development",
                "E-learning",
                "End-to-End",
                "Engine",
                "Enterprise Content Management – also known as ECM.",
                "Enterprise Service Bus – also known as ESB.",
                "Evolution - Often use ambiguously in political or sociological arguments in reference to theories of social Darwinism. (e.x. 'Society has evolved.')",
                "Framework",
                "Folksonomy",
                "Fuzzy logic",
                "Growth Hacking",
                "HTML5",
                "Immersion",
                "Information superhighway / Information highway",
                "Internet of Things",
                "Innovation",
                "Mashup",
                "Microservices",
                "Mobile",
                "Modularity",
                "Nanotechnology",
                "Netiquette",
                "NFV- Network Function virtualization",
                "Next Generation (also 'NextGen')",
                "Object-Oriented Programming",
                "Omnichannel",
                "Pandering",
                "Parsing",
                "PaaS",
                "Podcasting",
                "Portal",
                "Real-time",
                "Responsive Web Design",
                "Sensorization",
                "SaaS",
                "Scalability",
                "Skeuomorphic",
                "Social bookmarking",
                "Social software",
                "Software Defined _blank_",
                "SDN- Software defined Networking",
                "Spam",
                "Struts",
                "Sync-up",
                "Systems Development Life-Cycle",
                "Tagging",
                "Think outside the box",
                "Thought Leader",
                "Transmedia",
                "UC - Unified Communications",
                "User generated content",
                "Viral",
                "Virtualization",
                "Vlogging",
                "Vortal",
                "Web 2.0",
                "Webinar",
                "Weblog",
                "Web services",
                "Wikiality",
                "Workflow"
            };
        }
    }
}