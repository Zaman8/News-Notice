using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsNoticeHeadlines;


namespace Test {
    class Program {
        static void Main(string[] args) {
            adjective Nuclear = new adjective("Nuclear", -1, 1000, 500);
            noun Missile = new noun("Missile", -1, 1000, 500);
            verb Fires = new verb("Fires", -1, 1000, 250);
            properNoun America = new properNoun("America", 1, 1000, -100);
            Missile.addAdjective(Nuclear);
            Fires.addNoun(Missile);
            America.addNoun(Missile);
            America.addVerb(Fires);
            headline One = new headline();
            One.addProperNoun(America);
            One.generateHeadline();
            Console.WriteLine(One.getHeadline());
            Console.ReadLine();
        }
    }
}
