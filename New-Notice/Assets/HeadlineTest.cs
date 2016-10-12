using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class HeadlineTest : MonoBehaviour {
    private Text text;
    // Use this for initialization
    void Start() {
        adjective Nuclear = new adjective("Nuclear", -1, 1000, 500);
        noun Missile = new noun("Missile", -1, 800, 600);
        noun Cookie = new noun("Cookie", 1, -200, -240);
        verb Fires = new verb("Fires", -1, 800, 700);
        properNoun America = new properNoun("America", 1, 500, -200);
        America.addNoun(Missile);
        America.addNoun(Cookie);
        America.addVerb(Fires);
        Fires.addNoun(Missile);
        Missile.addAdjective(Nuclear);

        headline One = new headline();
        One.generateHeadline();
        text = gameObject.GetComponent<Text>();
        text.text = One.getHeadline();
    }

    // Update is called once per frame
    void Update() {

    }
}

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
        System.Random choice = new System.Random();
        properNoun = properNouns[choice.Next(0, properNouns.Count)];
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
                foreach (noun verbNoun in vlist.nouns) {
                    if (verbNoun.Equals(properNoun))
                        commonNouns.Add(verbNoun);
                }
            }
        int choice = UnityEngine.Random.Range(0, commonNouns.Count-1);
            return commonNouns[choice];
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
            this.word = word;
            this.good = good;
            this.viewers = viwers;
            this.chaos = chaos;
        }
        public verb verbChoice() {
        System.Random choice = new System.Random();
        return verbs[choice.Next(0, verbs.Count)];
        }
        public noun nounChoice() {
        System.Random choice = new System.Random();
        return nouns[choice.Next(0, nouns.Count)];
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
        System.Random choice = new System.Random();
        return nouns[choice.Next(0, nouns.Count)];
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
        System.Random choice = new System.Random();
            return adjectives[choice.Next(0, adjectives.Count)];
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
