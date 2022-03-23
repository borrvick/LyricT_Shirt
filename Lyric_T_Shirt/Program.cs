//Author: Ben Orrvick
//Purpose: Take Collection of songs and lyrics and make a new combined song out of the
//so the lyrics can be put on a shirt and sold as merch
//Date: 03/23/22

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


namespace Lyric_T_Shirt
{
    public class Program
    {
        //148 is the lngeth of the lyrics that will be on the shirt. It is based off of the length
        //hylow and it looks the best size wise
        const int LYRIC_LENGTH = 148;

        static void Main(string[] args)
        {
            //creates list to hold songs
            ArrayList lyricList = new ArrayList();
            List<string> orderedLyricList = new List<string>();
            List<string> cleanedLyricList = new List<string>();
            String lyricString = "";

            GetLyrics(lyricList);
            OrderLyrics(lyricList, orderedLyricList);
            CleanLyrics(orderedLyricList, cleanedLyricList);
            CreateLyricString(cleanedLyricList, lyricString);
            PrintFormattedList(cleanedLyricList);

        }


        //get lyrics from text files
        public static void GetLyrics(ArrayList lyricList)
        {
            //assigns all the song from txt files
            string[] amicablyLyrics = File.ReadAllText("Amicably.txt").Split(' ', '\n');
            lyricList.Add(amicablyLyrics);
            string[] attentionAddictLyrics = File.ReadAllText("Attention Addict.txt").Split(' ', '\n');
            lyricList.Add(attentionAddictLyrics);
            string[] maybeLyrics = File.ReadAllText("Maybe.txt").Split(' ', '\n');
            lyricList.Add(maybeLyrics);
            string[] cathecticLyrics = File.ReadAllText("Cathectic.txt").Split(' ', '\n');
            lyricList.Add(cathecticLyrics);
            string[] countingPlanesLyrics = File.ReadAllText("Counting Planes.txt").Split(' ', '\n');
            lyricList.Add(countingPlanesLyrics);
            string[] guiltGamesLyrics = File.ReadAllText("Guilt Games.txt").Split(' ', '\n');
            lyricList.Add(guiltGamesLyrics);
            string[] hylowLyrics = File.ReadAllText("Hylow.txt").Split(' ', '\n');
            lyricList.Add(hylowLyrics);
            string[] intricatedLyrics = File.ReadAllText("Intricated.txt").Split(' ', '\n');
            lyricList.Add(intricatedLyrics);
            string[] noButKindaLyrics = File.ReadAllText("No but kinda.txt").Split(' ', '\n');
            lyricList.Add(noButKindaLyrics);
            string[] windupLyrics = File.ReadAllText("Windup.txt").Split(' ', '\n');
            lyricList.Add(windupLyrics);
        }

        //order the different lyrics into one list
        public static void OrderLyrics(ArrayList pArrayList, List<string> pOrderedLyricList)
        {
            //current song being used
            int songNum = 0;
            //number of songs in list
            int numSongs = pArrayList.Count;

            //make sure we stay within word count
            for (int index = 0; index<LYRIC_LENGTH; index++)
            {
                //makes sure we stay within the amount of songs we have in list
                if (songNum > numSongs - 1){ songNum = 0; }
                //get song and assign it to temp var
                string[] tempSong = (string[]) pArrayList[songNum];
                //makes sure we dont go out of bounds
                if (index >= tempSong.Length-numSongs)
                {
                    //if list doesnt have enough words remove it
                    pArrayList.RemoveAt(songNum);
                    numSongs -= 1;
                }

                pOrderedLyricList.Add(tempSong[index]);
                songNum++;
            }

        }

        //get rid of punctuation and aposteophes and commas make all lowercase
        public static void CleanLyrics(List<string> pOrderedLyricList, List<string> pCleanedLyricList)
        {
            string tempLyric = "";
            foreach (string lyric in pOrderedLyricList)
            {
                tempLyric = lyric.Replace("?", String.Empty).Replace(",", String.Empty).Replace("’", String.Empty).Replace("!", String.Empty).Replace(".", String.Empty).Replace(" ", String.Empty).Replace("\n", String.Empty).Replace("\r", String.Empty);
                pCleanedLyricList.Add(tempLyric.ToLower());
            }
        }

        public static void CreateLyricString(List <string> pCleanedLyricList, string pLyricString)
        {
            foreach(string lyric in pCleanedLyricList){
                pLyricString += lyric + " ";
            }

            //uncomment to print chars
            //PrintStringChar(pLyricString);
        }

        //not my favorite the formatting is gross but in case you need it its here
        public static void PrintStringChar(string pLyricString)
        {

            foreach (char lyric in pLyricString)
            {
                Console.WriteLine(lyric);
            }
        }


        public static void PrintFormattedList(List<string> pCleanedLyricList)
        {
            //print 4 words per line
            for (int row = 0; row < pCleanedLyricList.Count; row += 4)
            {

                for (int x = row; x < row + 4; x++)
                {
                    Console.Write(pCleanedLyricList[x].ToString() + " ");

                }
                Console.Write("\r");
            }
        }

    }
} 
