using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;
public class LogicScript : MonoBehaviour
{

    [SerializeField]
    int numOfMines;
    public int itemIndex = 0;
    public int ZerosIndex = 1;
    public int[,] Board;

    public string[] Zeros;
   
    public bool isPressedOnce;

    public int maxX;
    public int maxY;

    public GameObject OriginalPosition;
    public GameObject num0Prefabs;
    public GameObject num1Prefabs;
    public GameObject num2Prefabs;
    public GameObject num3Prefabs;
    public GameObject num4Prefabs;
    public GameObject num5Prefabs;
    public GameObject num6Prefabs;
    public GameObject num7Prefabs;
    public GameObject num8Prefabs;


    public void minesLocation(string SqCoords)
    {
        string[] IncompatableMinesPoints = new string[numOfMines + 1];


        if (!isPressedOnce)
        {
            int countOfInitiatedMines = 0;
            IncompatableMinesPoints[0] = SqCoords;

            //this loop assigns the coords of the mines and creates an array of those coords.
            for (; countOfInitiatedMines < numOfMines;)
            {
                bool compatable = true;
                int randomX = Random.Range(0, maxX-1);
                int randomY = Random.Range(0, maxY-1);
                string compTest = randomX.ToString() + "." + randomY.ToString();



                foreach (var points in IncompatableMinesPoints)
                {
                    if (compTest == points)
                    {
                        compatable = false;
                    }
                }
                if (compatable == true)
                {
                    Board[randomX, randomY] = -1;
                    countOfInitiatedMines++;
                    IncompatableMinesPoints[countOfInitiatedMines] = compTest;
                }
                Debug.Log(IncompatableMinesPoints[countOfInitiatedMines]);
            }


            //this loop assigns the value for the squares around the mines.
            for (int X = 0; X < maxX; X++)
            {
                for (int Y = 0; Y < maxY; Y++)
                {

                    if (Board[X, Y] == -1)
                    {
                        if (X == maxX - 1 && Y != 0 && Y != maxY - 1)
                        {
                            Board[X - 1, Y] += 1;
                            Board[X, Y + 1] += 1;
                            Board[X, Y - 1] += 1;
                            Board[X - 1, Y - 1] += 1;
                            Board[X - 1, Y + 1] += 1;
                        }
                        else if (X == 0 && Y != 0 && Y != maxY - 1)
                        {
                            Board[X, Y + 1] += 1;
                            Board[X, Y - 1] += 1;
                            Board[X + 1, Y] += 1;
                            Board[X + 1, Y + 1] += 1;
                            Board[X + 1, Y - 1] += 1;
                        }
                        else if (Y == maxY - 1 && X != 0 && X != maxX - 1)
                        {
                            Board[X + 1, Y] += 1;
                            Board[X - 1, Y] += 1;
                            Board[X, Y - 1] += 1;
                            Board[X - 1, Y - 1] += 1;
                            Board[X + 1, Y - 1] += 1;
                        }
                        else if (Y == 0 && X != 0 && X != maxX - 1)
                        {
                            Board[X + 1, Y] += 1;
                            Board[X - 1, Y] += 1;
                            Board[X, Y + 1] += 1;
                            Board[X + 1, Y + 1] += 1;
                            Board[X - 1, Y + 1] += 1;
                        }
                        else if (X == 0 && Y == maxY - 1)
                        {
                            Board[X, Y - 1] += 1;
                            Board[X + 1, Y] += 1;
                            Board[X + 1, Y - 1] += 1;
                        }
                        else if (X == maxX - 1 && Y == 0)
                        {
                            Board[X - 1, Y] += 1;
                            Board[X, Y + 1] += 1;
                            Board[X - 1, Y + 1] += 1;
                        }
                        else if (X == maxX - 1 && Y == maxY - 1)
                        {
                            Board[X - 1, Y] += 1;
                            Board[X, Y - 1] += 1;
                            Board[X - 1, Y - 1] += 1;
                        }
                        else if (X == 0 && Y == 0)
                        {
                            Board[X, Y + 1] += 1;
                            Board[X + 1, Y] += 1;
                            Board[X + 1, Y + 1] += 1;
                        }
                        else
                        {
                            Board[X + 1, Y] += 1;
                            Board[X - 1, Y] += 1;
                            Board[X, Y + 1] += 1;
                            Board[X, Y - 1] += 1;
                            Board[X + 1, Y + 1] += 1;
                            Board[X - 1, Y - 1] += 1;
                            Board[X + 1, Y - 1] += 1;
                            Board[X - 1, Y + 1] += 1;


                        }
                    }


                    //this loop makes sure that the value of the mines isnt overwritten by the previous loop.
                    for (int i = 1; i < countOfInitiatedMines + 1; i++)
                    {
                        string arrayelmi = IncompatableMinesPoints[i];

                        if (Board[int.Parse(arrayelmi.Substring(0, arrayelmi.IndexOf("."))), int.Parse(arrayelmi.Substring(arrayelmi.IndexOf(".") + 1))] != -1)
                        {
                            Board[int.Parse(arrayelmi.Substring(0, arrayelmi.IndexOf("."))), int.Parse(arrayelmi.Substring(arrayelmi.IndexOf(".") + 1))] = -1;
                        }
                    }

                }
            }
        }
        isPressedOnce = true;
    }

    public int squaresValue(string coordinates)
    {

        int ChosenX = int.Parse(coordinates.Substring(0, coordinates.IndexOf(".")));
        int ChosenY = int.Parse(coordinates.Substring(coordinates.IndexOf(".") + 1));
        Debug.Log(ChosenX + "<-ChosenX , ChosenY->" + ChosenY+" , Coordinates->"+coordinates);

        return Board[ChosenX, ChosenY];

    }

    public void zerosCheck(string[] coordinates)
    {

        int RecIndex = 0;
        string CurrentItem = coordinates[itemIndex];

        Debug.Log("current item"+CurrentItem);
        int ChosenX = int.Parse(CurrentItem.Substring(0, CurrentItem.IndexOf(".")));
        int ChosenY = int.Parse(CurrentItem.Substring(CurrentItem.IndexOf(".") + 1));
       
        int x = ChosenX;
        int y = ChosenY;

        //this loop checks for the values of the square around the pressed square, and stores it insde an array
        //this part below checks for squares with value of zero in the north direction and it adds them into an array

        for (; x < maxX;)
        {
            string tempCoords = x.ToString() + "." + y.ToString();

            if (Board[x, y] == 0)
            {

                if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
     
                x++;
                  if (IsInZeros(tempCoords) == false && x<maxX)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
            } 
            else
            {
                if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
                break;
            }

        }


        //this part below checks for squares with value of zero in the south direction and it adds them into an array

        x = ChosenX;
        y = ChosenY;

        for (; x >= 0;)
        {
            string tempCoords = x.ToString() + "." + y.ToString();
            if (Board[x, y] == 0)
            {

                if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }

                x--;
                if (IsInZeros(tempCoords) == false && x >=0)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
            }
            else
            {
                if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
                break;
            }
        }


        //this part below checks for squares with value of zero in the west direction and it adds them into an array

        x = ChosenX;
        y = ChosenY;
        for (; y >= 0;)
        {
            string tempCoords = x.ToString() + "." + y.ToString();
            if (Board[x, y] == 0)
            {

                if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }

                y--;
                  if (IsInZeros(tempCoords) == false && y >=0)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
            }
            else
            {
                if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
                break;
            }
        }


        //this part below checks for squares with value of zero in the east direction and it adds them into an array

        x = ChosenX;
        y = ChosenY;
        for (; y < maxY;)
        {
            string tempCoords = x.ToString() + "." + y.ToString();
            if (Board[x, y] == 0)
            {

                if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }

                y++;
                 if (IsInZeros(tempCoords) == false&&y<maxY)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
            }
            else
            {
               if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
                break;
            }

        }


        //this part below checks for squares with value of zero in the northeast direction and it adds them into an array

        x = ChosenX;
        y = ChosenY;

        for (; y < maxY && x >= 0;)
        {
            string tempCoords = x.ToString() + "." + y.ToString();
            
            if (Board[x, y] == 0)
            {

                if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }

                y++;
                x--;
                if (IsInZeros(tempCoords) == false&& y < maxY && x >= 0)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }

            }
            else
            {
                if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
                break;
            }

        }


        //this part below checks for squares with value of zero in the northwest direction and it adds them into an array

        x = ChosenX;
        y = ChosenY;

        for (; y >= 0 && x >= 0;)
        {
            string tempCoords = x.ToString() + "." + y.ToString();
            if (Board[x, y] == 0)
            {


                if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
                
                x--;
                y--;
                 if (IsInZeros(tempCoords) == false&& y >= 0 && x >= 0)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
            }
            else
            {
                if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
                break;
            }

        }


        //this part below checks for squares with value of zero in the southwest direction and it adds them into an array            

        x = ChosenX;
        y = ChosenY;

        for (; y >= 0 && x < maxX;)
        {
            string tempCoords = x.ToString() + "." + y.ToString();
            if (Board[x, y] == 0)
            {


                if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
                
                x++;
                y--;
                
                if (IsInZeros(tempCoords) == false&& y >= 0 && x < maxX)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
            }
            else
            {
               if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
                break;
            }

        }


        //this part below checks for squares with value of zero in the southeast direction and it adds them into an array

        x = ChosenX;
        y = ChosenY;

        for (; y < maxY && x < maxX;)
        {
            string tempCoords = x.ToString() + "." + y.ToString();
            if (Board[x, y] == 0)
            {


                if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
                
                y++;
                x++;
                
                if (IsInZeros(tempCoords) == false&& y < maxY && x < maxX)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
            }
            else
            {
               if (IsInZeros(tempCoords) == false)
                {
                    Zeros[ZerosIndex] = tempCoords;
                    ZerosIndex++;
                }
                break;
            }

        }

        ZerosFeedBack(Zeros);

    }

    public void ZerosFeedBack(string [] ZerosCoords)
    {

        int numOfZeros = ZerosIndex;
        Debug.Log("itemidex is " + itemIndex + " num of zeros is = " + numOfZeros);
        
        if (itemIndex <numOfZeros-1)
        {
            itemIndex++;
            zerosCheck(ZerosCoords);

        }
        else
        {
            // this loop  instantiates the prefaps for the coords inside of the array

           
            for (int counter = 0; counter <ZerosIndex; counter++)
            {

                string coordsCheck = Zeros[counter];
                if (coordsCheck?.Length >= 2)
                {

                    int X = int.Parse(coordsCheck.Substring(0, coordsCheck.IndexOf(".")));
                    int Y = int.Parse(coordsCheck.Substring(coordsCheck.IndexOf(".") + 1));
                    spwaningValues(X, Y, squaresValue(coordsCheck));
                }
                else
                {
                    Array.Clear(Zeros, 0, Zeros.Length);
                    break;
                }
            }
         
        }
    }

    public bool IsInZeros(string Subject)
    {
        bool dublicate = false;
        foreach (var item in Zeros)
        {
            if(Subject == item)
            {
                dublicate = true;
            }
        }
        return dublicate;
    }


    public void spwaningValues(int X, int y, int Value)
    {
        Debug.Log("spawning values has been called X is " + X + " Y is " + y);
        float squarewidth = 2.05f;
        Vector3 valueposition = OriginalPosition.transform.position + new Vector3(squarewidth * X + squarewidth / 2, .332f, squarewidth * y + squarewidth / 2); ;



        if (Value == 0)
        {
            Vector3 positionCorrction = new Vector3(0.171f - .18f, 0f, -0.54799f - .05f);

            Instantiate(num0Prefabs, valueposition + positionCorrction, Quaternion.Euler(0, 0, 180));
        }
        else if (Value == 1)
        {
            Vector3 positionCorrction = new Vector3(-.27f, 0f, -.595f);
            Instantiate(num1Prefabs, valueposition + positionCorrction, Quaternion.Euler(0, 0, 180));
        }
        else if (Value == 2)
        {
            Vector3 positionCorrction = new Vector3(0.171f, 0f, -0.54799f);
            Instantiate(num2Prefabs, valueposition + positionCorrction, Quaternion.Euler(0, 0, 180));
        }
        else if (Value == 3)
        {
            Vector3 positionCorrction = new Vector3(0.045f, 0f, -.619999f);
            Instantiate(num3Prefabs, valueposition + positionCorrction, Quaternion.Euler(0, 0, 180));
        }
        else if (Value == 4)
        {
            Vector3 positionCorrction = new Vector3(.368f, 0f, -.519f);

            Instantiate(num4Prefabs, valueposition + positionCorrction, Quaternion.Euler(0, 0, 180));
        }
        else if (Value == 5)
        {
            Vector3 positionCorrction = new Vector3(0.171f - .18f, 0f, -0.54799f - .05f);
            Instantiate(num5Prefabs, valueposition + positionCorrction, Quaternion.Euler(0, 0, 180));
        }
        else if (Value == 6)
        {
            Vector3 positionCorrction = new Vector3(0.171f - .18f, 0f, -0.54799f - .05f);
            Instantiate(num6Prefabs, valueposition + positionCorrction, Quaternion.Euler(0, 0, 180));
        }
        else if (Value == 7)
        {
            Vector3 positionCorrction = new Vector3(0.171f - .18f - .09f, 0f, -0.54799f - .05f + .232f);
            Instantiate(num7Prefabs, valueposition + positionCorrction, Quaternion.Euler(0, 0, 180));
        }
        else if (Value == 8)
        {
            Vector3 positionCorrction = new Vector3(0.171f - .18f, 0f, -0.54799f - .05f);
            Instantiate(num8Prefabs, valueposition + positionCorrction, Quaternion.Euler(0, 0, 180));
        }
    }


}
