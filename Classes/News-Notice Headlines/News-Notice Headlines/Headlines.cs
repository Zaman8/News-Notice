﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsNoticeHeadlines
{
    public class headline {
        List<properNoun> properNouns = new List<properNoun>();
        properNoun properNoun = null;
        verb verb = null;
        noun noun = null;
        adjective adjective = null;
        string[] headlines = new string[4];
        public int viewers;
        public int chaos;
        public int good;
        public void generateHeadline() {
            Random choice = new Random();
            properNoun = properNouns[choice.Next(properNouns.Count)];
            verb = properNoun.verbChoice();
            noun = nounChoice(properNoun, verb);
            adjective = noun.adjectiveChoice();
            viewers = properNoun.viewers + verb.viewers + noun.viewers + adjective.viewers;
            chaos = properNoun.chaos + verb.chaos + noun.chaos + adjective.chaos;
            good = properNoun.good * verb.good * noun.good * adjective.good;
        }
        private noun nounChoice(properNoun plist, verb vlist) {
            List<noun> commonNouns = new List<noun>();
            foreach (noun properNoun in plist.nouns) {
                foreach(noun verbNoun in vlist.nouns) {
                    if (verbNoun.Equals(properNoun))
                        commonNouns.Add(verbNoun);
                }
            }
            Random choice = new Random();
            return commonNouns[choice.Next(commonNouns.Count)];
        }
        public string getHeadline() {
            headlines[0] = properNoun.word;
            headlines[1] = verb.word;
            headlines[2] = adjective.word;
            headlines[3] = noun.word;

            return String.Format("{0} {1} {2} {3}", headlines[0], headlines[1], headlines[2], headlines[3]);
        }
        public void addProperNoun(properNoun noun) {
            properNouns.Add(noun);
        }
    }
    public class properNoun {
        public string word;
        List<verb> verbs = new List<verb>();
        public List<noun> nouns = new List<noun>();
        public int good;
        public int viewers;
        public int chaos;
        public properNoun(string word, int good, int viwers, int chaos) {
            this.word = word ;
            this.good = good;
            this.viewers = viwers;
            this.chaos = chaos;
        }
       public verb verbChoice() {
            Random choice = new Random();
            return verbs[choice.Next(verbs.Count)];
        }
        public noun nounChoice() {
            Random choice = new Random();
            return nouns[choice.Next(nouns.Count)];
        }
        public void addVerb(verb verb) {
            verbs.Add(verb);
        }
        public void addNoun(noun noun) {
            nouns.Add(noun);
        }
    }
    public class verb {
        public string word;
        public List<noun> nouns = new List<noun>();
        public int good;
        public int viewers;
        public int chaos;
        public verb(string word, int good, int viewers, int chaos) {
            this.word = word;
            this.good = good;
            this.viewers = viewers;
            this.chaos = chaos;
        }
        public noun nounChoice() {
            Random choice = new Random();
            return nouns[choice.Next(nouns.Count)];
        }
        public void addNoun(noun noun) {
            nouns.Add(noun);
        }
    }
    public class noun {
        public string word;
        List<adjective> adjectives = new List<adjective>();
        public int good;
        public int viewers;
        public int chaos;
        public noun(string word, int good, int viewers, int chaos) {
            this.word = word;
            this.good = good;
            this.viewers = viewers;
            this.chaos = chaos;
        }
        public adjective adjectiveChoice() {
            Random choice = new Random();
            return adjectives[choice.Next(adjectives.Count)];
        }
        public void addAdjective(adjective adjective) {
            adjectives.Add(adjective);
        }
    }
    public class adjective {
        public string word;
        public int good;
        public int viewers;
        public int chaos;
        public adjective(string word, int good, int viewers, int chaos) {
            this.word = word;
            this.good = good;
            this.viewers = viewers;
            this.chaos = chaos;
        }
    }
}
