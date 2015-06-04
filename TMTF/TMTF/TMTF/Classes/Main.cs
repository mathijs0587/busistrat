/* Gemaakt door Mathijs Parie & Desley van Rees
 * TMTFT
 * 
 * Uitleg:
 * Dit is de basis van het spel en hier komen alle puzzelstukjes bij elkaar om
 * het spel te laten werken. Dit is de Main class.
 */

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TMTF.Classes
{
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        #region Textures
        /* Deze "Region" is voor het declareren
         * van alle Textures. Deze Textures worden
         * gebruikt in de LoadContent functie.
        */
        Texture2D tile;

        Texture2D dicesTexture;

        Texture2D unit_p1; //rood
        Texture2D unit_p2; //blauw65
        Texture2D unit_p3; //groen
        Texture2D unit_p4; //geel

        Texture2D base_p1; //rood
        Texture2D base_p2; //blauw
        Texture2D base_p3; //groen
        Texture2D base_p4; //geel

        Texture2D background;
        Texture2D scoreboard;

        Texture2D inGameMenu_links;
        Texture2D inGameMenu_rechts;
        Texture2D inGameMenuGreenScreen_links;
        Texture2D inGameMenuGreenScreen_rechts;

        Texture2D uitlegWindowTexture;
        Texture2D closeUitlegButtonTexture;

        Texture2D gameOverScreenTexture;
        Texture2D gameOverButtonGreenScreenOpnieuw;
        Texture2D gameOverButtonGreenScreenHoofdmenu;

        Texture2D mainMenuTexture;
        Texture2D startGameButton;
        Texture2D stoppenButton;
        #endregion

        #region VideoPlayer
        Video video;
        VideoPlayer videoPlayer;
        Texture2D videoTexture;
        #endregion

        #region Fonts
        SpriteFont digitalFont;
        SpriteFont mainFont;
        SpriteFont scoreFont;
        #endregion

        #region TileStruct
        /* Deze Struct is gemaakt om een groep
         * van variables the encapsuleren.
         */
        public struct TileStruct
        {
            public int tileNumber;
            public Vector2 tilePos;
            public Color tileColor;
            public bool hasUnit;
            public int playerUnit;
            public float playerRotation;
            public int unitPower;
            public bool isSelected;
            public bool hasBase;
            public int playerBase;
        }
        #endregion

        #region Dices
        String diceStringOne;
        String diceStringTwo;
        public int diceLoop;
        public bool canRoll;
        #endregion

        #region mouseClickInfo
        string sColorval = "";
        uint[] myUint = new uint[1];

        int selectedTile = -1;

        string sColorTile = "4294967295";
        #endregion

        #region Colors
        Color cWhite = new Color(255, 255, 255);
        Color cRed = new Color(90, 7, 7);
        Color cBlue = new Color(4, 73, 117);
        Color cGreen = new Color(41,117, 7);
        Color cYellow = new Color(200, 130, 20);
        Color cGray = new Color(1, 1, 1);
        Color cScore = new Color(200, 200, 200);
        #endregion

        #region PlayerInfo
        public struct PlayerInfo
        {
            public int units;
            public int score;
            public int hp;
            public Color playerColor;
            public bool hasMoved;
            public bool hasRolled;
            public bool isGameOver;
            public bool hasBase;
        }
        #endregion

        #region tempColors
        Color tempColor1;
        Color tempColor2;
        Color tempColor3;
        Color tempColor4;
        Color tempColor5;
        Color tempColor6;
        #endregion

        #region tempTiles
        int tempTile1;
        int tempTile2;
        int tempTile3;
        int tempTile4;
        int tempTile5;
        int tempTile6;
        #endregion

        #region EventStates
        MouseState newMouseState;
        MouseState oldMouseState;
        KeyboardState oldKeyboardState;
        KeyboardState newKeyboardState;
        #endregion

        #region Uitleg
        public bool uitlegPopUp = false;
        public bool closeUitlegBoolean = false;
        #endregion

        #region Random
        Random playerOneRandom = new Random();
        Random playerTwoRandom = new Random();
        Random playerThreeRandom = new Random();
        Random playerFourRandom = new Random();
        #endregion

        #region MainMenu
        bool mainMenuActivated = true;
        #endregion

        int counter = 0;
        int playerBeurt = 1;
        bool gameOverBoolean = false;

        //Het uitvragen van de eerste int uit de struct TileInfo
        TileStruct[] tileStruct = new TileStruct[25];
        PlayerInfo[] playerInfo = new PlayerInfo[5];

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 630;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            #region TilePositioning
                //Een tile te positioneren op de waarde van de Vector2
                #region RowOne
                tileStruct[0].tilePos = new Vector2(180, 267);
                #endregion
                #region RowTwo
                tileStruct[1].tilePos = new Vector2(270, 216);
                tileStruct[2].tilePos = new Vector2(270, 319);
                #endregion
                #region RowThree
                tileStruct[3].tilePos = new Vector2(360, 164);
                tileStruct[4].tilePos = new Vector2(360, 267);
                tileStruct[5].tilePos = new Vector2(360, 370);
                #endregion
                #region RowFour
                tileStruct[6].tilePos = new Vector2(450, 113);
                tileStruct[7].tilePos = new Vector2(450, 216);
                tileStruct[8].tilePos = new Vector2(450, 319);
                tileStruct[9].tilePos = new Vector2(450, 422);
                #endregion
                #region RowFive
                tileStruct[10].tilePos = new Vector2(540, 61);
                tileStruct[11].tilePos = new Vector2(540, 164);
                tileStruct[12].tilePos = new Vector2(540, 267);
                tileStruct[13].tilePos = new Vector2(540, 370);
                tileStruct[14].tilePos = new Vector2(540, 473);
                #endregion
                #region RowSix
                tileStruct[15].tilePos = new Vector2(630, 113);
                tileStruct[16].tilePos = new Vector2(630, 216);
                tileStruct[17].tilePos = new Vector2(630, 319);
                tileStruct[18].tilePos = new Vector2(630, 422);
                #endregion
                #region RowSeven
                tileStruct[19].tilePos = new Vector2(720, 164);
                tileStruct[20].tilePos = new Vector2(720, 267);
                tileStruct[21].tilePos = new Vector2(720, 370);
                #endregion
                #region RowEigth
                tileStruct[22].tilePos = new Vector2(810, 216);
                tileStruct[23].tilePos = new Vector2(810, 319);
                #endregion
                #region RowNine
                tileStruct[24].tilePos = new Vector2(900, 267);
                #endregion
            #endregion

            #region TileColouring
                //Een tile in te kleuren op een basis van een rgb waarde
                #region RowOne
                tileStruct[0].tileColor = cBlue;
                #endregion
                #region RowTwo
                tileStruct[1].tileColor = cWhite;
                tileStruct[2].tileColor = cWhite;
                #endregion
                #region RowThree
                tileStruct[3].tileColor = cWhite;
                tileStruct[4].tileColor = cWhite;
                tileStruct[5].tileColor = cWhite;
                #endregion
                #region RowFour
                tileStruct[6].tileColor = cWhite;
                tileStruct[7].tileColor = cWhite;
                tileStruct[8].tileColor = cWhite;
                tileStruct[9].tileColor = cWhite;
                #endregion
                #region RowFive
                tileStruct[10].tileColor = cGreen;
                tileStruct[11].tileColor = cWhite;
                tileStruct[12].tileColor = cWhite;
                tileStruct[13].tileColor = cWhite;
                tileStruct[14].tileColor = cRed;
                #endregion
                #region RowSix
                tileStruct[15].tileColor = cWhite;
                tileStruct[16].tileColor = cWhite;
                tileStruct[17].tileColor = cWhite;
                tileStruct[18].tileColor = cWhite;
                #endregion
                #region RowSeven
                tileStruct[19].tileColor = cWhite;
                tileStruct[20].tileColor = cWhite;
                tileStruct[21].tileColor = cWhite;
                #endregion
                #region RowEigth
                tileStruct[22].tileColor = cWhite;
                tileStruct[23].tileColor = cWhite;
                #endregion
                #region RowNine
                tileStruct[24].tileColor = cYellow;
                #endregion
            #endregion

            #region TileNumbering
                //Een tile in te kleuren op een basis van een rgb waarde
                #region RowOne
                tileStruct[0].tileNumber = 0;
                #endregion
                #region RowTwo
                tileStruct[1].tileNumber = 11;
                tileStruct[2].tileNumber = 10;
                #endregion
                #region RowThree
                tileStruct[3].tileNumber = 22;
                tileStruct[4].tileNumber = 21;
                tileStruct[5].tileNumber = 20;
                #endregion
                #region RowFour
                tileStruct[6].tileNumber = 33;
                tileStruct[7].tileNumber = 32;
                tileStruct[8].tileNumber = 31;
                tileStruct[9].tileNumber = 30;
                #endregion
                #region RowFive
                tileStruct[10].tileNumber = 44;
                tileStruct[11].tileNumber = 43;
                tileStruct[12].tileNumber = 42;
                tileStruct[13].tileNumber = 41;
                tileStruct[14].tileNumber = 40;
                #endregion
                #region RowSix
                tileStruct[15].tileNumber = 54;
                tileStruct[16].tileNumber = 53;
                tileStruct[17].tileNumber = 52;
                tileStruct[18].tileNumber = 51;
                #endregion
                #region RowSeven
                tileStruct[19].tileNumber = 64;
                tileStruct[20].tileNumber = 63;
                tileStruct[21].tileNumber = 62;
                #endregion
                #region RowEigth
                tileStruct[22].tileNumber = 74;
                tileStruct[23].tileNumber = 73;
                #endregion
                #region RowNine
                tileStruct[24].tileNumber = 84;
                #endregion
                #endregion

            #region BeginSpelers
            tileStruct[13].hasUnit = true;
            tileStruct[13].playerUnit = 1;
            tileStruct[13].playerRotation = 0f;
            tileStruct[13].unitPower = playerOneRandom.Next(1, 4);
            tileStruct[13].tileColor = cRed;

            tileStruct[1].hasUnit = true;
            tileStruct[1].playerUnit = 2;
            tileStruct[1].playerRotation = 1f;
            tileStruct[1].unitPower = playerTwoRandom.Next(1, 4);
            tileStruct[1].tileColor = cBlue;

            tileStruct[11].hasUnit = true;
            tileStruct[11].playerUnit = 3;
            tileStruct[11].playerRotation = 2f;
            tileStruct[11].unitPower = playerThreeRandom.Next(1, 4);
            tileStruct[11].tileColor = cGreen;

            tileStruct[23].hasUnit = true;
            tileStruct[23].playerUnit = 4;
            tileStruct[23].playerRotation = 3f;
            tileStruct[23].unitPower = playerFourRandom.Next(1, 4);
            tileStruct[23].tileColor = cYellow;

            playerInfo[1].playerColor = cRed;
            playerInfo[2].playerColor = cBlue;
            playerInfo[3].playerColor = cGreen;
            playerInfo[4].playerColor = cYellow;

            if (tileStruct[13].unitPower == tileStruct[1].unitPower)
            {
                tileStruct[1].unitPower = playerTwoRandom.Next(1, 4);
            }

            if (tileStruct[11].unitPower == tileStruct[1].unitPower)
            {
                tileStruct[1].unitPower = playerTwoRandom.Next(1, 4);
            }

            if (tileStruct[23].unitPower == tileStruct[1].unitPower)
            {
                tileStruct[1].unitPower = playerTwoRandom.Next(1, 4);
            }

            if (tileStruct[1].unitPower == tileStruct[11].unitPower)
            {
                tileStruct[11].unitPower = playerThreeRandom.Next(1, 4);
            }

            if (tileStruct[13].unitPower == tileStruct[11].unitPower)
            {
                tileStruct[11].unitPower = playerThreeRandom.Next(1, 4);
            }
            if (tileStruct[23].unitPower == tileStruct[11].unitPower)
            {
                tileStruct[11].unitPower = playerThreeRandom.Next(1, 4);
            }

            if (tileStruct[11].unitPower == tileStruct[23].unitPower)
            {
                tileStruct[23].unitPower = playerFourRandom.Next(1, 4);
            }

            if (tileStruct[1].unitPower == tileStruct[23].unitPower)
            {
                tileStruct[23].unitPower = playerFourRandom.Next(1, 4);
            }

            if (tileStruct[13].unitPower == tileStruct[23].unitPower)
            {
                tileStruct[23].unitPower = playerFourRandom.Next(1, 4);
            }
            #endregion

            #region playerBase
            tileStruct[14].hasBase = true;
            tileStruct[0].hasBase = true;
            tileStruct[10].hasBase = true;
            tileStruct[24].hasBase = true;

            tileStruct[14].playerBase = 1;
            tileStruct[0].playerBase = 2;
            tileStruct[10].playerBase = 3;
            tileStruct[24].playerBase = 4;

            playerInfo[1].hp = 10;
            playerInfo[2].hp = 10;
            playerInfo[3].hp = 10;
            playerInfo[4].hp = 10;
            #endregion

            #region InstellenPlayerInfo
            playerInfo[1].hasMoved = false;
            playerInfo[1].hasRolled = false;
            playerInfo[1].isGameOver = false;
            playerInfo[1].units = 1;

            playerInfo[2].hasMoved = false;
            playerInfo[2].hasRolled = false;
            playerInfo[2].isGameOver = false;
            playerInfo[2].units = 1;

            playerInfo[3].hasMoved = false;
            playerInfo[3].hasRolled = false;
            playerInfo[3].isGameOver = false;
            playerInfo[3].units = 1;

            playerInfo[4].hasMoved = false;
            playerInfo[4].hasRolled = false;
            playerInfo[4].isGameOver = false;
            playerInfo[4].units = 1;
            #endregion

            diceStringOne = "0";
            diceStringTwo = "0";

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Het laden van de Textures uit the region Textures
            #region TexturesLoading
            tile = Content.Load<Texture2D>("Sprites\\Tile\\White_Hexagon");

            dicesTexture = Content.Load<Texture2D>("Sprites\\Dices\\Dobbelsteen");

            unit_p1 = Content.Load<Texture2D>("Sprites\\Units\\Unit_Rood");
            unit_p2 = Content.Load<Texture2D>("Sprites\\Units\\Unit_Blauw");
            unit_p3 = Content.Load<Texture2D>("Sprites\\Units\\Unit_Groen");
            unit_p4 = Content.Load<Texture2D>("Sprites\\Units\\Unit_Geel");

            base_p1 = Content.Load<Texture2D>("Sprites\\Base\\Rood_Fabriek");
            base_p2 = Content.Load<Texture2D>("Sprites\\Base\\Blauw_Fabriek");
            base_p3 = Content.Load<Texture2D>("Sprites\\Base\\Groen_Fabriek");
            base_p4 = Content.Load<Texture2D>("Sprites\\Base\\Geel_Fabriek");

            background = Content.Load<Texture2D>("Sprites\\Background\\Background");
            scoreboard = Content.Load<Texture2D>("Sprites\\Scoreboard\\Scoreboard");

            inGameMenu_links = Content.Load<Texture2D>("Sprites\\Toolbar\\inGameMenu_links");
            inGameMenu_rechts = Content.Load<Texture2D>("Sprites\\Toolbar\\inGameMenu_rechts");
            inGameMenuGreenScreen_links = Content.Load<Texture2D>("Sprites\\Toolbar\\inGameMenuGreenScreen_links");
            inGameMenuGreenScreen_rechts = Content.Load<Texture2D>("Sprites\\Toolbar\\inGameMenuGreenScreen_rechts");

            mainMenuTexture = Content.Load<Texture2D>("Sprites\\MainMenu\\MainMenuTexture");
            startGameButton = Content.Load<Texture2D>("Sprites\\MainMenu\\StartGameButton");
            stoppenButton = Content.Load<Texture2D>("Sprites\\MainMenu\\StoppenButton");

            closeUitlegButtonTexture = Content.Load<Texture2D>("Sprites\\Toolbar\\CloseUitlegButton");
            uitlegWindowTexture = Content.Load<Texture2D>("Sprites\\Toolbar\\Uitleg");

            gameOverScreenTexture = Content.Load<Texture2D>("Sprites\\GameOver\\GameOverScreen");
            gameOverButtonGreenScreenOpnieuw = Content.Load<Texture2D>("Sprites\\GameOver\\GameOverButtonGreenScreen");
            gameOverButtonGreenScreenHoofdmenu = Content.Load<Texture2D>("Sprites\\GameOver\\GameOverButtonGreenScreen");
            #endregion

            #region FontsLoading
            digitalFont = Content.Load<SpriteFont>("Fonts\\DigitalFont");
            mainFont = Content.Load<SpriteFont>("Fonts\\mainFont");
            scoreFont = Content.Load<SpriteFont>("Fonts\\scoreFont");
            #endregion

            #region VideoLoading
            
            video = Content.Load<Video>("Video\\MainMenuVideo");
            videoPlayer = new VideoPlayer();
            #endregion

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            newMouseState = Mouse.GetState();
            newKeyboardState = Keyboard.GetState();

            if (newMouseState.LeftButton == ButtonState.Pressed)
            {
               
            }
            else if (oldMouseState.LeftButton == ButtonState.Pressed)
            {
                clickTile(newMouseState.X, newMouseState.Y);
                ClickButtonLinks(newMouseState.X, newMouseState.Y);
                ClickButtonRechts(newMouseState.X, newMouseState.Y);
                CloseUitleg(newMouseState.X, newMouseState.Y);
                OpnieuwButton(newMouseState.X, newMouseState.Y);
                HoofdmenuButton(newMouseState.X, newMouseState.Y);
                StartGameButton(newMouseState.X, newMouseState.Y);
                StoppenButton(newMouseState.X, newMouseState.Y);
            }

            if(uitlegPopUp == false)
            {
            playerInfo[1].hasBase = tileStruct[14].hasBase;
            playerInfo[2].hasBase = tileStruct[0].hasBase;
            playerInfo[3].hasBase = tileStruct[10].hasBase;
            playerInfo[4].hasBase = tileStruct[24].hasBase;

            if (playerInfo[1].units == 0 && !playerInfo[1].hasBase) { playerInfo[1].isGameOver = true; }

            if (playerInfo[2].units == 0 && !playerInfo[2].hasBase) { playerInfo[2].isGameOver = true; }

            if (playerInfo[3].units == 0 && !playerInfo[3].hasBase) { playerInfo[3].isGameOver = true; }

            if (playerInfo[4].units == 0 && !playerInfo[4].hasBase) { playerInfo[4].isGameOver = true; }

            if (playerInfo[1].hp <= 0)
            {
                playerInfo[1].hasBase = false;
                tileStruct[14].hasBase = false;

            }
            else
            {
                playerInfo[1].hasBase = true;
                tileStruct[14].hasBase = true;
            }

            if (playerInfo[2].hp <= 0)
            {
                playerInfo[2].hasBase = false;
                tileStruct[0].hasBase = false;
                
            }
            else
            {
                playerInfo[2].hasBase = true;
                tileStruct[0].hasBase = true;
            }

            if (playerInfo[3].hp <= 0)
            {
                playerInfo[3].hasBase = false;
                tileStruct[10].hasBase = false;
            }
            else
            {
                playerInfo[3].hasBase = true;
                tileStruct[10].hasBase = true;
            }

            if (playerInfo[4].hp <= 0)
            {
                playerInfo[4].hasBase = false;
                tileStruct[24].hasBase = false;
                
            }
            else
            {
                playerInfo[4].hasBase = true;
                tileStruct[24].hasBase = true;
            }

            for (int i = 0; i < 5; i++)
            {
                if (playerInfo[i].isGameOver == true)
                {
                    counter++;
                }
                if (counter >= 3)
                {
                    gameOverBoolean = true;
                }
            }
            counter = 0;

            if (playerInfo[playerBeurt].isGameOver)
            {
                verwisselBeurt();
            }
            else
            {

                if (playerInfo[playerBeurt].hasMoved || playerInfo[playerBeurt].units == 0)
                {
                    if (playerInfo[playerBeurt].units <= 0)
                    {
                        playerInfo[playerBeurt].hasMoved = true;
                    }

                    if (canRoll == true)
                    {
                        while (diceLoop < 100)
                        {
                            diceStringOne = RandomDice().ToString();
                            diceLoop++;
                            break;
                        }
                        while (diceLoop < 152)
                        {
                            diceStringTwo = RandomDice().ToString();
                            diceLoop++;
                            break;
                        }
                    }
                    if (diceLoop >= 152)
                    {
                        diceLoop = 0;
                        canRoll = false;
                        
                        int power = Convert.ToInt32(diceStringOne);
                        power += Convert.ToInt32(diceStringTwo);
                        if (power % 2 == 1)
                        {

                        }
                        else
                        {
                            if (!tileStruct[14].hasUnit && tileStruct[14].hasBase && tileStruct[14].playerBase == playerBeurt && !playerInfo[1].isGameOver)
                            {
                                tileStruct[14].hasUnit = true;
                                tileStruct[14].unitPower = power / 2;
                                tileStruct[14].playerUnit = 1;
                                playerInfo[1].units += 1;
                                playerInfo[1].hp -= 1;
                            }

                            if (!tileStruct[0].hasUnit && tileStruct[0].hasBase && tileStruct[0].playerBase == playerBeurt && !playerInfo[2].isGameOver)
                            {
                                tileStruct[0].hasUnit = true;
                                tileStruct[0].unitPower = power / 2;
                                tileStruct[0].playerUnit = 2;
                                playerInfo[2].units += 1;
                                playerInfo[2].hp -= 1;
                            }

                            if (!tileStruct[10].hasUnit && tileStruct[10].hasBase && tileStruct[10].playerBase == playerBeurt && !playerInfo[3].isGameOver)
                            {
                                tileStruct[10].hasUnit = true;
                                tileStruct[10].unitPower = power / 2;
                                tileStruct[10].playerUnit = 3;
                                playerInfo[3].units += 1;
                                playerInfo[3].hp -= 1;
                            }

                            if (!tileStruct[24].hasUnit && tileStruct[24].hasBase && tileStruct[24].playerBase == playerBeurt && !playerInfo[4].isGameOver)
                            {
                                tileStruct[24].hasUnit = true;
                                tileStruct[24].unitPower = power / 2;
                                tileStruct[24].playerUnit = 4;
                                playerInfo[4].units += 1;
                                playerInfo[4].hp -= 1;
                            }
                        }
                        playerInfo[playerBeurt].hasRolled = true;
                    }
                    }
                }
            }

            if (playerInfo[playerBeurt].hasMoved && playerInfo[playerBeurt].hasRolled)
            {
                verwisselBeurt();
            }

            if (videoPlayer.State == MediaState.Stopped)
            {
                videoPlayer.IsLooped = true;
                videoPlayer.Play(video);
            }

            oldMouseState = newMouseState;
            oldKeyboardState = newKeyboardState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            if (mainMenuActivated == false)
            {
            #region EnviormentDrawing
            //Background
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(scoreboard, new Vector2(0, 0), Color.White);
            #endregion

            #region TileDrawing
                #region RowOne
                spriteBatch.Draw(tile, tileStruct[0].tilePos, tileStruct[0].tileColor);
                #endregion
                #region RowTwo
                spriteBatch.Draw(tile, tileStruct[1].tilePos, tileStruct[1].tileColor);
                spriteBatch.Draw(tile, tileStruct[2].tilePos, tileStruct[2].tileColor);
                #endregion
                #region RowThree
                spriteBatch.Draw(tile, tileStruct[3].tilePos, tileStruct[3].tileColor);
                spriteBatch.Draw(tile, tileStruct[4].tilePos, tileStruct[4].tileColor);
                spriteBatch.Draw(tile, tileStruct[5].tilePos, tileStruct[5].tileColor);
                #endregion
                #region RowFour
                spriteBatch.Draw(tile, tileStruct[6].tilePos, tileStruct[6].tileColor);
                spriteBatch.Draw(tile, tileStruct[7].tilePos, tileStruct[7].tileColor);
                spriteBatch.Draw(tile, tileStruct[8].tilePos, tileStruct[8].tileColor);
                spriteBatch.Draw(tile, tileStruct[9].tilePos, tileStruct[9].tileColor);
                #endregion
                #region RowFive
                spriteBatch.Draw(tile, tileStruct[10].tilePos, tileStruct[10].tileColor);
                spriteBatch.Draw(tile, tileStruct[11].tilePos, tileStruct[11].tileColor);
                spriteBatch.Draw(tile, tileStruct[12].tilePos, tileStruct[12].tileColor);
                spriteBatch.Draw(tile, tileStruct[13].tilePos, tileStruct[13].tileColor);
                spriteBatch.Draw(tile, tileStruct[14].tilePos, tileStruct[14].tileColor);
                #endregion
                #region RowSix
                spriteBatch.Draw(tile, tileStruct[15].tilePos, tileStruct[15].tileColor);
                spriteBatch.Draw(tile, tileStruct[16].tilePos, tileStruct[16].tileColor);
                spriteBatch.Draw(tile, tileStruct[17].tilePos, tileStruct[17].tileColor);
                spriteBatch.Draw(tile, tileStruct[18].tilePos, tileStruct[18].tileColor);
                #endregion
                #region RowSeven
                spriteBatch.Draw(tile, tileStruct[19].tilePos, tileStruct[19].tileColor);
                spriteBatch.Draw(tile, tileStruct[20].tilePos, tileStruct[20].tileColor);
                spriteBatch.Draw(tile, tileStruct[21].tilePos, tileStruct[21].tileColor);
                #endregion
                #region RowEight
                spriteBatch.Draw(tile, tileStruct[22].tilePos, tileStruct[22].tileColor);
                spriteBatch.Draw(tile, tileStruct[23].tilePos, tileStruct[23].tileColor);
                #endregion
                #region RowNine

                spriteBatch.Draw(tile, tileStruct[24].tilePos, tileStruct[24].tileColor);
                #endregion
            #endregion

            #region DiceDrawing
            //Dice 1
            spriteBatch.Draw(dicesTexture, new Vector2(477, 0), new Color(175, 175, 175));
            spriteBatch.DrawString(digitalFont, "8", new Vector2(507, -4), new Color(200, 200, 200));
            spriteBatch.DrawString(digitalFont, diceStringOne, new Vector2(507, -4), new Color(100, 100, 100));

            //Dice 2
            spriteBatch.Draw(dicesTexture, new Vector2(621, 0), new Color(175, 175, 175));
            spriteBatch.DrawString(digitalFont, "8", new Vector2(651, -4), new Color(200, 200, 200));
            spriteBatch.DrawString(digitalFont, diceStringTwo, new Vector2(651, -4), new Color(100, 100, 100));
            #endregion

            #region BaseDrawing
            if (playerInfo[1].hp > 0)
            {
                spriteBatch.Draw(base_p1, new Vector2(tileStruct[14].tilePos.X + (tile.Width / 2), tileStruct[14].tilePos.Y + (tile.Height / 2)), new Rectangle(0, 0, base_p1.Width, base_p1.Height), Color.White, 0f * MathHelper.PiOver2, new Vector2(base_p1.Width / 2, base_p1.Height / 2), 0.8f, SpriteEffects.None, 0);
            }
            if (playerInfo[2].hp > 0)
            {
                spriteBatch.Draw(base_p2, new Vector2(tileStruct[0].tilePos.X + (tile.Width / 2), tileStruct[0].tilePos.Y + (tile.Height / 2)), new Rectangle(0, 0, base_p2.Width, base_p2.Height), Color.White, 1f * MathHelper.PiOver2, new Vector2(base_p2.Width / 2, base_p2.Height / 2), 0.8f, SpriteEffects.None, 0);
            }
            if (playerInfo[3].hp > 0)
            {
                spriteBatch.Draw(base_p3, new Vector2(tileStruct[10].tilePos.X + (tile.Width / 2), tileStruct[10].tilePos.Y + (tile.Height / 2)), new Rectangle(0, 0, base_p3.Width, base_p3.Height), Color.White, 2f * MathHelper.PiOver2, new Vector2(base_p3.Width / 2, base_p3.Height / 2), 0.8f, SpriteEffects.None, 0);

            }
            if (playerInfo[4].hp > 0)
            {
                spriteBatch.Draw(base_p4, new Vector2(tileStruct[24].tilePos.X + (tile.Width / 2), tileStruct[24].tilePos.Y + (tile.Height / 2)), new Rectangle(0, 0, base_p4.Width, base_p4.Height), Color.White, 3f * MathHelper.PiOver2, new Vector2(base_p4.Width / 2, base_p4.Height / 2), 0.8f, SpriteEffects.None, 0);
            }
            #endregion

            #region ScoreText
            //Player 1
            spriteBatch.DrawString(mainFont, "Speler 1", new Vector2(20, 450), cWhite);
            spriteBatch.DrawString(mainFont, "Units: " + playerInfo[1].units.ToString(), new Vector2(20, 470), cWhite);
            spriteBatch.DrawString(mainFont, "Punten: " + playerInfo[1].score.ToString(), new Vector2(20, 490), cWhite);
            spriteBatch.DrawString(mainFont, "Arbeiders: " + playerInfo[1].hp.ToString(), new Vector2(20, 510), cWhite);
            if (playerBeurt == 1)
            {
                spriteBatch.DrawString(mainFont, "Het is jouw beurt! ", new Vector2(20, 550), cWhite);
            }

            //Player2
            spriteBatch.DrawString(mainFont, "Speler 2", new Vector2(20, 10), cWhite);
            spriteBatch.DrawString(mainFont, "Units: " + playerInfo[2].units.ToString(), new Vector2(20, 30), cWhite);
            spriteBatch.DrawString(mainFont, "Punten: " + playerInfo[2].score.ToString(), new Vector2(20, 50), cWhite);
            spriteBatch.DrawString(mainFont, "Arbeiders: " + playerInfo[2].hp.ToString(), new Vector2(20, 70), cWhite);
            if (playerBeurt == 2)
            {
                spriteBatch.DrawString(mainFont, "Het is jouw beurt! ", new Vector2(20, 110), cWhite);
            }
            
            //Player 3
            spriteBatch.DrawString(mainFont, "Speler 3", new Vector2(1030, 10), cWhite);
            spriteBatch.DrawString(mainFont, "Units: " + playerInfo[3].units.ToString(), new Vector2(1030, 30), cWhite);
            spriteBatch.DrawString(mainFont, "Punten: " + playerInfo[3].score.ToString(), new Vector2(1030, 50), cWhite);
            spriteBatch.DrawString(mainFont, "Arbeiders: " + playerInfo[3].hp.ToString(), new Vector2(1030, 70), cWhite);
            if (playerBeurt == 3)
            {
                spriteBatch.DrawString(mainFont, "Het is jouw beurt! ", new Vector2(1030, 110), cWhite);
            }

            //Player 4
            spriteBatch.DrawString(mainFont, "Speler 4", new Vector2(1030, 450), cWhite);
            spriteBatch.DrawString(mainFont, "Units: " + playerInfo[4].units.ToString(), new Vector2(1030, 470), cWhite);
            spriteBatch.DrawString(mainFont, "Punten: " + playerInfo[4].score.ToString(), new Vector2(1030, 490), cWhite);
            spriteBatch.DrawString(mainFont, "Arbeiders: " + playerInfo[4].hp.ToString(), new Vector2(1030, 510), cWhite);
            if (playerBeurt == 4)
            {
                spriteBatch.DrawString(mainFont, "Het is jouw beurt! ", new Vector2(1030, 550), cWhite);
            }
            #endregion

            #region PlayerDrawing
            for (int i = 0; i < tileStruct.Length; i++)
            {
                //spriteBatch.DrawString(mainFont, tileStruct[i].tileNumber.ToString() + "\n" + tileStruct[i].playerUnit.ToString(), new Vector2(tileStruct[i].tilePos.X + 50, tileStruct[i].tilePos.Y + 50), Color.Black);
                if (tileStruct[i].playerUnit == 1)
                {
                    spriteBatch.Draw(unit_p1, new Vector2(tileStruct[i].tilePos.X + (tile.Width / 2), tileStruct[i].tilePos.Y + (tile.Height / 2)), new Rectangle(0, 0, unit_p1.Width, unit_p1.Height), Color.White, tileStruct[i].playerRotation * MathHelper.PiOver2, new Vector2(unit_p1.Width / 2, unit_p1.Height / 2), 1, SpriteEffects.None, 0);
                }
                if (tileStruct[i].playerUnit == 2)
                {
                    spriteBatch.Draw(unit_p2, new Vector2(tileStruct[i].tilePos.X + (tile.Width / 2), tileStruct[i].tilePos.Y + (tile.Height / 2)), new Rectangle(0, 0, unit_p2.Width, unit_p2.Height), Color.White, tileStruct[i].playerRotation * MathHelper.PiOver2, new Vector2(unit_p2.Width / 2, unit_p2.Height / 2), 1, SpriteEffects.None, 0);
                }
                if (tileStruct[i].playerUnit == 3)
                {
                    spriteBatch.Draw(unit_p3, new Vector2(tileStruct[i].tilePos.X + (tile.Width / 2), tileStruct[i].tilePos.Y + (tile.Height / 2)), new Rectangle(0, 0, unit_p3.Width, unit_p3.Height), Color.White, tileStruct[i].playerRotation * MathHelper.PiOver2, new Vector2(unit_p3.Width / 2, unit_p3.Height / 2), 1, SpriteEffects.None, 0);
                }
                if (tileStruct[i].playerUnit == 4)
                {
                    spriteBatch.Draw(unit_p4, new Vector2(tileStruct[i].tilePos.X + (tile.Width / 2), tileStruct[i].tilePos.Y + (tile.Height / 2)), new Rectangle(0, 0, unit_p4.Width, unit_p4.Height), Color.White, tileStruct[i].playerRotation * MathHelper.PiOver2, new Vector2(unit_p4.Width / 2, unit_p4.Height / 2), 1, SpriteEffects.None, 0);
                }

                if (tileStruct[i].unitPower > 0)
                {
                    spriteBatch.DrawString(mainFont, tileStruct[i].unitPower.ToString(), new Vector2(tileStruct[i].tilePos.X +80, tileStruct[i].tilePos.Y + 10), cWhite);
                }
            }
            #endregion

            #region ToolbarDrawing
            //Green Screen Textures
            spriteBatch.Draw(inGameMenuGreenScreen_links, new Vector2(0, 250), new Color(175, 175, 175));
            spriteBatch.Draw(inGameMenuGreenScreen_rechts, new Vector2(1114, 250), new Color(175, 175, 175));

            //Real Textures
            spriteBatch.Draw(inGameMenu_links, new Vector2(0, 250), new Color(175, 175, 175));
            spriteBatch.Draw(inGameMenu_rechts, new Vector2(1114, 250), new Color(175, 175, 175));
            #endregion

            #region UitlegDrawing
            if (uitlegPopUp == true)
            {
                spriteBatch.Draw(closeUitlegButtonTexture, new Vector2(524, 562), Color.White);
                spriteBatch.Draw(uitlegWindowTexture, new Vector2(0, 0), Color.White);
            }
            #endregion

            #region GameOverDrawing
            if (gameOverBoolean == true)
            {
                string winString = "";
                spriteBatch.Draw(gameOverButtonGreenScreenOpnieuw, new Vector2(142, 483), new Color(175, 175, 175));
                spriteBatch.Draw(gameOverButtonGreenScreenHoofdmenu, new Vector2(736, 483), new Color(175, 175, 175));
                spriteBatch.Draw(gameOverScreenTexture, new Vector2(0, 0), new Color(175, 175, 175));

                winString += "Speler 1 heeft " + playerInfo[1].score + " punten. \n";
                winString += "Speler 2 heeft " + playerInfo[2].score + " punten. \n";
                winString += "Speler 3 heeft " + playerInfo[3].score + " punten. \n";
                winString += "Speler 4 heeft " + playerInfo[4].score + " punten. \n";
                spriteBatch.DrawString(scoreFont, winString, new Vector2(405, 235), cScore);
            }
            #endregion

            }
            if (mainMenuActivated == true)
            {
                #region MenuDrawing
                if (videoPlayer.State != MediaState.Stopped)
                {
                    videoTexture = videoPlayer.GetTexture();
                }

                Rectangle screen = new Rectangle(GraphicsDevice.Viewport.X,
                    GraphicsDevice.Viewport.Y,
                    GraphicsDevice.Viewport.Width,
                    GraphicsDevice.Viewport.Height + 1);

                if (videoTexture != null)
                {
                    spriteBatch.Draw(videoTexture, screen, Color.White);
                    spriteBatch.Draw(stoppenButton, new Rectangle(0, 405, stoppenButton.Width, stoppenButton.Height), Color.White);
                    spriteBatch.Draw(startGameButton, new Rectangle(0, 282, startGameButton.Width, startGameButton.Height), Color.White);
                    spriteBatch.Draw(mainMenuTexture, new Rectangle(0, 0, mainMenuTexture.Width, mainMenuTexture.Height), Color.White);
                }
                #endregion
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void clickTile(int mX, int mY)
        {
                        if (mainMenuActivated == false)
            {
            if (gameOverBoolean == false)
            {
                if (uitlegPopUp == false)
                {
                    for (int i = 0; i < tileStruct.Length; i++)
                    {
                        int tileX = (int)tileStruct[i].tilePos.X;
                        int tileY = (int)tileStruct[i].tilePos.Y;

                        if (newMouseState.X >= tileX
                            && newMouseState.X < tileX + tile.Width
                            && newMouseState.Y >= tileY
                            && newMouseState.Y < tileY + tile.Height)
                        {
                            tile.GetData<uint>(0, new Rectangle(newMouseState.X - tileX, newMouseState.Y - tileY, 1, 1), myUint, 0, 1);
                            sColorval = myUint[0].ToString();

                            if (myUint[0] > 0)
                            {
                                if (tileStruct[i].hasUnit == true
                                    && tileStruct[i].playerUnit == playerBeurt
                                    && tileStruct[i].tileColor != cGray
                                    && selectedTile < 0
                                    && !playerInfo[playerBeurt].hasMoved)
                                {
                                    selectedTile = i;
                                    tileStruct[i].isSelected = true;
                                    for (int c = 0; c < tileStruct.Length; c++)
                                    {
                                        if (tileStruct[c].tileNumber == tileStruct[i].tileNumber + 1)
                                        {
                                            tempColor4 = tileStruct[c].tileColor;
                                            tempTile4 = c;
                                            tileStruct[c].playerRotation = 0f;
                                            tileStruct[c].tileColor = Color.Lerp(cGray, tempColor4, 0.5f);
                                        }

                                        if (tileStruct[c].tileNumber == tileStruct[i].tileNumber - 1)
                                        {
                                            tempColor1 = tileStruct[c].tileColor;
                                            tempTile1 = c;
                                            tileStruct[c].playerRotation = 2f;
                                            tileStruct[c].tileColor = Color.Lerp(cGray, tempColor1, 0.5f);
                                        }
                                        if (tileStruct[c].tileNumber == tileStruct[i].tileNumber - 10)
                                        {
                                            tempColor2 = tileStruct[c].tileColor;
                                            tempTile2 = c;
                                            tileStruct[c].playerRotation = 3.4f;
                                            tileStruct[c].tileColor = Color.Lerp(cGray, tempColor2, 0.5f); ;
                                        }
                                        if (tileStruct[c].tileNumber == tileStruct[i].tileNumber - 11)
                                        {
                                            tempColor3 = tileStruct[c].tileColor;
                                            tempTile3 = c;
                                            tileStruct[c].playerRotation = 2.6f;
                                            tileStruct[c].tileColor = Color.Lerp(cGray, tempColor3, 0.5f);
                                        }
                                        if (tileStruct[c].tileNumber == tileStruct[i].tileNumber + 10)
                                        {
                                            tempColor5 = tileStruct[c].tileColor;
                                            tempTile5 = c;
                                            tileStruct[c].playerRotation = 1.4f;
                                            tileStruct[c].tileColor = Color.Lerp(cGray, tempColor5, 0.5f);
                                        }
                                        if (tileStruct[c].tileNumber == tileStruct[i].tileNumber + 11)
                                        {
                                            tempColor6 = tileStruct[c].tileColor;
                                            tempTile6 = c;
                                            tileStruct[c].playerRotation = 0.6f;
                                            tileStruct[c].tileColor = Color.Lerp(cGray, tempColor6, 0.5f); ;
                                        }

                                    }

                                }

                                if (tileStruct[i].isSelected == false
                                    && selectedTile >= 0
                                    && tileStruct[i].tileColor == Color.Lerp(cGray, tempColor1, 0.5f)
                                    || tileStruct[i].tileColor == Color.Lerp(cGray, tempColor2, 0.5f)
                                    || tileStruct[i].tileColor == Color.Lerp(cGray, tempColor3, 0.5f)
                                    || tileStruct[i].tileColor == Color.Lerp(cGray, tempColor4, 0.5f)
                                    || tileStruct[i].tileColor == Color.Lerp(cGray, tempColor5, 0.5f)
                                    || tileStruct[i].tileColor == Color.Lerp(cGray, tempColor6, 0.5f))
                                {
                                    Console.WriteLine(tileStruct[9].tileColor.ToString());
                                    Console.WriteLine(tempTile1.ToString() + " " + tempTile2.ToString() + " " + tempTile3.ToString() + " " + tempTile4.ToString() + " " + tempTile5.ToString() + " " + tempTile6.ToString());
                                    if (tempTile1 != -1)
                                    {
                                        tileStruct[tempTile1].tileColor = tempColor1;
                                    }
                                    if (tempTile2 != -1)
                                    {
                                        tileStruct[tempTile2].tileColor = tempColor2;
                                    }
                                    if (tempTile3 != -1)
                                    {
                                        tileStruct[tempTile3].tileColor = tempColor3;
                                    }
                                    if (tempTile4 != -1)
                                    {
                                        tileStruct[tempTile4].tileColor = tempColor4;
                                    }
                                    if (tempTile5 != -1)
                                    {
                                        tileStruct[tempTile5].tileColor = tempColor5;
                                    }
                                    if (tempTile6 != -1)
                                    {
                                        tileStruct[tempTile6].tileColor = tempColor6;
                                    }

                                    tempTile1 = -1;
                                    tempTile2 = -1;
                                    tempTile3 = -1;
                                    tempTile4 = -1;
                                    tempTile5 = -1;
                                    tempTile6 = -1;

                                    if (tileStruct[i].hasUnit == true && tileStruct[i].playerUnit != playerBeurt && !playerInfo[playerBeurt].hasMoved)
                                    {
                                        if (tileStruct[i].unitPower < tileStruct[selectedTile].unitPower)
                                        {
                                            tileStruct[selectedTile].unitPower -= tileStruct[i].unitPower;
                                            playerInfo[tileStruct[i].playerUnit].units -= 1;

                                            if (tileStruct[i].hasBase)
                                            {
                                                

                                                tileStruct[i].hasUnit = false;
                                                tileStruct[i].playerUnit = 0;
                                                tileStruct[i].unitPower = 0;
                                                playerInfo[playerBeurt].units -= 1;

                                                if (playerInfo[tileStruct[i].playerBase].hp <= tileStruct[selectedTile].unitPower)
                                                {
                                                    tileStruct[i].hasBase = false;
                                                    playerInfo[tileStruct[i].playerBase].isGameOver = true;
                                                    playerInfo[tileStruct[i].playerBase].hp = 0;
                                                    playerInfo[tileStruct[i].playerBase].score += 3;
                                                }

                                                playerInfo[tileStruct[i].playerBase].hp -= tileStruct[selectedTile].unitPower;
                                            }
                                            else
                                            {
                                                tileStruct[i].hasUnit = tileStruct[selectedTile].hasUnit;
                                                tileStruct[i].tileColor = tileStruct[selectedTile].tileColor;
                                                tileStruct[i].playerUnit = tileStruct[selectedTile].playerUnit;
                                                tileStruct[i].unitPower = tileStruct[selectedTile].unitPower;
                                                playerInfo[playerBeurt].hp += 1;
                                            }


                                            tileStruct[selectedTile].hasUnit = false;

                                            tileStruct[selectedTile].playerUnit = 0;

                                            tileStruct[selectedTile].unitPower = 0;
                                            playerInfo[playerBeurt].score++;
                                            playerInfo[playerBeurt].hasMoved = true;

                                        }
                                        else if (tileStruct[i].unitPower > tileStruct[selectedTile].unitPower && !playerInfo[playerBeurt].hasMoved)
                                        {
                                            tileStruct[i].unitPower -= tileStruct[selectedTile].unitPower;
                                            tileStruct[selectedTile].hasUnit = false;
                                            tileStruct[selectedTile].playerUnit = 0;
                                            tileStruct[selectedTile].unitPower = 0;
                                            playerInfo[playerBeurt].units -= 1;
                                            playerInfo[tileStruct[i].playerUnit].hp += 1;
                                            playerInfo[playerBeurt].hasMoved = true;
                                        }
                                        else if (tileStruct[i].unitPower == tileStruct[selectedTile].unitPower && !playerInfo[playerBeurt].hasMoved)
                                        {
                                            playerInfo[tileStruct[i].playerUnit].units -= 1;
                                            playerInfo[playerBeurt].units -= 1;

                                            tileStruct[selectedTile].hasUnit = false;
                                            tileStruct[selectedTile].playerUnit = 0;
                                            tileStruct[selectedTile].unitPower = 0;

                                            tileStruct[i].hasUnit = false;
                                            tileStruct[i].playerUnit = 0;
                                            tileStruct[i].unitPower = 0;
                                            playerInfo[playerBeurt].hasMoved = true;
                                        }
                                    }
                                    else if (tileStruct[i].hasUnit == false && tileStruct[i].hasBase == false && !playerInfo[playerBeurt].hasMoved)
                                    {
                                        if (tileStruct[i].tileColor != playerInfo[playerBeurt].playerColor)
                                        {
                                            playerInfo[playerBeurt].score++;
                                        }

                                        tileStruct[i].hasUnit = tileStruct[selectedTile].hasUnit;
                                        tileStruct[selectedTile].hasUnit = false;

                                        tileStruct[i].tileColor = tileStruct[selectedTile].tileColor;

                                        tileStruct[i].playerUnit = tileStruct[selectedTile].playerUnit;
                                        tileStruct[selectedTile].playerUnit = 0;

                                        tileStruct[i].unitPower = tileStruct[selectedTile].unitPower;
                                        tileStruct[selectedTile].unitPower = 0;
                                        playerInfo[playerBeurt].hasMoved = true;

                                    }
                                    else if (tileStruct[i].hasBase == true)
                                    {
                                        if (playerInfo[tileStruct[i].playerBase].hp <= tileStruct[selectedTile].unitPower && tileStruct[i].playerBase != playerBeurt && !playerInfo[playerBeurt].hasMoved)
                                        {
                                            tileStruct[selectedTile].hasUnit = false;
                                            tileStruct[i].hasBase = false;

                                            playerInfo[tileStruct[i].playerBase].hp = 0;

                                            tileStruct[selectedTile].playerUnit = 0;

                                            tileStruct[selectedTile].unitPower = 0;

                                            playerInfo[playerBeurt].score += 3;
                                            playerInfo[playerBeurt].units -= 1;
                                            playerInfo[playerBeurt].hasMoved = true;
                                        }
                                        else if (playerInfo[tileStruct[i].playerBase].hp > tileStruct[selectedTile].unitPower && tileStruct[i].playerBase != playerBeurt && !playerInfo[playerBeurt].hasMoved)
                                        {
                                            playerInfo[tileStruct[i].playerBase].hp -= tileStruct[selectedTile].unitPower;
                                            tileStruct[selectedTile].hasUnit = false;
                                            tileStruct[selectedTile].playerUnit = 0;
                                            tileStruct[selectedTile].unitPower = 0;

                                            playerInfo[playerBeurt].units -= 1;
                                            playerInfo[playerBeurt].hasMoved = true;
                                        }
                                        else if (playerInfo[tileStruct[i].playerBase].hp == tileStruct[selectedTile].unitPower && tileStruct[i].playerBase != playerBeurt && !playerInfo[playerBeurt].hasMoved)
                                        {
                                            tileStruct[selectedTile].hasUnit = false;
                                            tileStruct[selectedTile].playerUnit = 0;
                                            tileStruct[selectedTile].unitPower = 0;

                                            tileStruct[i].hasUnit = false;
                                            tileStruct[i].playerUnit = 0;
                                            tileStruct[i].unitPower = 0;

                                            playerInfo[playerBeurt].units -= 1;
                                            playerInfo[playerBeurt].hasMoved = true;
                                        }
                                    }
                                    tileStruct[selectedTile].isSelected = false;

                                    selectedTile = -1;

                                }
                                Console.WriteLine(tileStruct[i].tileNumber.ToString() + " - " + i.ToString());
                            }
                        }
                    }
                    }
                }
            }
        }

        public void ClickButtonLinks(int mX, int mY)
        {
            if(mainMenuActivated == false)
            {
                if (gameOverBoolean == false)
                {
                    int buttonX = 0;
                    int buttonY = 250;

                    if (mX >= buttonX
                        && mX < buttonX + inGameMenuGreenScreen_links.Width
                        && mY >= buttonY
                        && mY < buttonY + inGameMenuGreenScreen_links.Height)
                    {
                        inGameMenuGreenScreen_links.GetData<uint>(0, new Rectangle(mX - buttonX, mY - buttonY, 1, 1), myUint, 0, 1);
                        sColorval = myUint[0].ToString();

                        if (sColorval == "4279435008")
                        {
                            uitlegPopUp = true;
                        }
                    }
                }
            }
        }

        public void ClickButtonRechts(int mX, int mY)
        {
            if(mainMenuActivated == false)
            {
                if (gameOverBoolean == false)
                {
                    if (uitlegPopUp == false)
                    {
                        int buttonX = 1114;
                        int buttonY = 250;

                        if (mX >= buttonX
                            && mX < buttonX + inGameMenuGreenScreen_rechts.Width
                            && mY >= buttonY
                            && mY < buttonY + inGameMenuGreenScreen_rechts.Height)
                        {
                            inGameMenuGreenScreen_rechts.GetData<uint>(0, new Rectangle(mX - buttonX, mY - buttonY, 1, 1), myUint, 0, 1);
                            sColorval = myUint[0].ToString();

                            if (sColorval == "4279435008")
                            {
                                canRoll = true;
                            }
                        }
                    }
                }
            }
        }

        public void CloseUitleg(int mX, int mY)
        {
            if (mainMenuActivated == false)
            {
                int buttonX = 524;
                int buttonY = 562;

                if (mX >= buttonX
                    && mX < buttonX + closeUitlegButtonTexture.Width
                    && mY >= buttonY
                    && mY < buttonY + closeUitlegButtonTexture.Height)
                {
                    closeUitlegButtonTexture.GetData<uint>(0, new Rectangle(mX - buttonX, mY - buttonY, 1, 1), myUint, 0, 1);
                    sColorval = myUint[0].ToString();

                    uitlegPopUp = false;
                    Console.WriteLine(sColorval);
                }
            }
        }

        public void OpnieuwButton(int mX, int mY)
        {
            if (mainMenuActivated == false)
            {
                int buttonX = 142;
                int buttonY = 483;

                if (mX >= buttonX
                    && mX < buttonX + gameOverButtonGreenScreenOpnieuw.Width
                    && mY >= buttonY
                    && mY < buttonY + gameOverButtonGreenScreenOpnieuw.Height)
                {
                    gameOverButtonGreenScreenOpnieuw.GetData<uint>(0, new Rectangle(mX - buttonX, mY - buttonY, 1, 1), myUint, 0, 1);
                    sColorval = myUint[0].ToString();

                    reset();
                }
            }
        }

        public void HoofdmenuButton(int mX, int mY)
        {
            int buttonX = 746;
            int buttonY = 483;

            if (mX >= buttonX
                && mX < buttonX + gameOverButtonGreenScreenHoofdmenu.Width
                && mY >= buttonY
                && mY < buttonY + gameOverButtonGreenScreenHoofdmenu.Height)
            {
                gameOverButtonGreenScreenHoofdmenu.GetData<uint>(0, new Rectangle(mX - buttonX, mY - buttonY, 1, 1), myUint, 0, 1);
                sColorval = myUint[0].ToString();

                mainMenuActivated = true;
                reset();
            }
        }

        public void StartGameButton(int mX, int mY)
        {
            int buttonX = 0;
            int buttonY = 282;

            if (mX >= buttonX
                && mX < buttonX + startGameButton.Width
                && mY >= buttonY
                && mY < buttonY + startGameButton.Height)
            {
                startGameButton.GetData<uint>(0, new Rectangle(mX - buttonX, mY - buttonY, 1, 1), myUint, 0, 1);
                sColorval = myUint[0].ToString();

                if (mainMenuActivated == true)
                {
                        mainMenuActivated = false;
                    }
                }
        }

        public void StoppenButton(int mX, int mY)
        {
            int buttonX = 0;
            int buttonY = 405;

            if (mX >= buttonX
                && mX < buttonX + stoppenButton.Width
                && mY >= buttonY
                && mY < buttonY + stoppenButton.Height)
            {
                stoppenButton.GetData<uint>(0, new Rectangle(mX - buttonX, mY - buttonY, 1, 1), myUint, 0, 1);
                sColorval = myUint[0].ToString();

                if (mainMenuActivated == true)
                {
                    this.Exit();
                }
            }
        }

        public void verwisselBeurt()
        {
            playerInfo[playerBeurt].hasMoved = false;
            playerInfo[playerBeurt].hasRolled = false;
            playerBeurt++;
            playerBeurt = playerBeurt % 5;
            if (playerBeurt == 0)
            {
                playerBeurt = 1;
            }
        }

        public int RandomDice()
        {
            Random randomRandomNumber = new Random();
            int randomIntNumber = randomRandomNumber.Next(1, 7);
            return randomIntNumber;
        }

        public void reset()
        {
            gameOverBoolean = false;

            for (int i = 0; i < 25; i++)
            {
                tileStruct[i].hasUnit = false;
                tileStruct[i].hasBase = false;
                tileStruct[i].isSelected = false;
                tileStruct[i].unitPower = 0;
                tileStruct[i].playerUnit = 0;
                tileStruct[i].playerBase = 0;
            }
            for (int i = 0; i < 5; i++ )
            {
                playerInfo[i].hasBase = false;
                playerInfo[i].hasMoved = false;
                playerInfo[i].hasRolled = false;
                playerInfo[i].hp = 0;
                playerInfo[i].isGameOver = false;
                playerInfo[i].score = 0;
                playerInfo[i].units = 0;
            }
            #region TileColouring
            //Een tile in te kleuren op een basis van een rgb waarde
            #region RowOne
            tileStruct[0].tileColor = cBlue;
            #endregion
            #region RowTwo
            tileStruct[1].tileColor = cWhite;
            tileStruct[2].tileColor = cWhite;
            #endregion
            #region RowThree
            tileStruct[3].tileColor = cWhite;
            tileStruct[4].tileColor = cWhite;
            tileStruct[5].tileColor = cWhite;
            #endregion
            #region RowFour
            tileStruct[6].tileColor = cWhite;
            tileStruct[7].tileColor = cWhite;
            tileStruct[8].tileColor = cWhite;
            tileStruct[9].tileColor = cWhite;
            #endregion
            #region RowFive
            tileStruct[10].tileColor = cGreen;
            tileStruct[11].tileColor = cWhite;
            tileStruct[12].tileColor = cWhite;
            tileStruct[13].tileColor = cWhite;
            tileStruct[14].tileColor = cRed;
            #endregion
            #region RowSix
            tileStruct[15].tileColor = cWhite;
            tileStruct[16].tileColor = cWhite;
            tileStruct[17].tileColor = cWhite;
            tileStruct[18].tileColor = cWhite;
            #endregion
            #region RowSeven
            tileStruct[19].tileColor = cWhite;
            tileStruct[20].tileColor = cWhite;
            tileStruct[21].tileColor = cWhite;
            #endregion
            #region RowEigth
            tileStruct[22].tileColor = cWhite;
            tileStruct[23].tileColor = cWhite;
            #endregion
            #region RowNine
            tileStruct[24].tileColor = cYellow;
            #endregion
            #endregion

            #region BeginSpelers
            tileStruct[13].hasUnit = true;
            tileStruct[13].playerUnit = 1;
            tileStruct[13].unitPower = 1;
            tileStruct[13].tileColor = cRed;

            tileStruct[1].hasUnit = true;
            tileStruct[1].playerUnit = 2;
            tileStruct[1].unitPower = 1;
            tileStruct[1].tileColor = cBlue;

            tileStruct[11].hasUnit = true;
            tileStruct[11].playerUnit = 3;
            tileStruct[11].unitPower = 1;
            tileStruct[11].tileColor = cGreen;

            tileStruct[23].hasUnit = true;
            tileStruct[23].playerUnit = 4;
            tileStruct[23].unitPower = 1;
            tileStruct[23].tileColor = cYellow;

            playerInfo[1].playerColor = cRed;
            playerInfo[2].playerColor = cBlue;
            playerInfo[3].playerColor = cGreen;
            playerInfo[4].playerColor = cYellow;
            #endregion

            #region playerBase
            tileStruct[14].hasBase = true;
            tileStruct[0].hasBase = true;
            tileStruct[10].hasBase = true;
            tileStruct[24].hasBase = true;

            tileStruct[14].playerBase = 1;
            tileStruct[0].playerBase = 2;
            tileStruct[10].playerBase = 3;
            tileStruct[24].playerBase = 4;

            playerInfo[1].hasBase = true;
            playerInfo[2].hasBase = true;
            playerInfo[3].hasBase = true;
            playerInfo[4].hasBase = true;

            playerInfo[1].hp = 10;
            playerInfo[2].hp = 10;
            playerInfo[3].hp = 10;
            playerInfo[4].hp = 10;
            #endregion

            #region InstellenPlayerInfo
            playerInfo[1].hasMoved = false;
            playerInfo[1].hasRolled = false;
            playerInfo[1].isGameOver = false;
            playerInfo[1].units = 1;

            playerInfo[2].hasMoved = false;
            playerInfo[2].hasRolled = false;
            playerInfo[2].isGameOver = false;
            playerInfo[2].units = 1;

            playerInfo[3].hasMoved = false;
            playerInfo[3].hasRolled = false;
            playerInfo[3].isGameOver = false;
            playerInfo[3].units = 1;

            playerInfo[4].hasMoved = false;
            playerInfo[4].hasRolled = false;
            playerInfo[4].isGameOver = false;
            playerInfo[4].units = 1;
            #endregion

            diceStringOne = "0";
            diceStringTwo = "0";

            #region BeginSpelers
            tileStruct[13].hasUnit = true;
            tileStruct[13].playerUnit = 1;
            tileStruct[13].unitPower = playerOneRandom.Next(1, 4);
            tileStruct[13].tileColor = cRed;

            tileStruct[1].hasUnit = true;
            tileStruct[1].playerUnit = 2;
            tileStruct[1].unitPower = playerTwoRandom.Next(1, 4);
            tileStruct[1].tileColor = cBlue;

            tileStruct[11].hasUnit = true;
            tileStruct[11].playerUnit = 3;
            tileStruct[11].unitPower = playerThreeRandom.Next(1, 4);
            tileStruct[11].tileColor = cGreen;

            tileStruct[23].hasUnit = true;
            tileStruct[23].playerUnit = 4;
            tileStruct[23].unitPower = playerFourRandom.Next(1, 4);
            tileStruct[23].tileColor = cYellow;

            playerInfo[1].playerColor = cRed;
            playerInfo[2].playerColor = cBlue;
            playerInfo[3].playerColor = cGreen;
            playerInfo[4].playerColor = cYellow;

            if (tileStruct[13].unitPower == tileStruct[1].unitPower)
            {
                tileStruct[1].unitPower = playerTwoRandom.Next(1, 4);
            }

            if (tileStruct[11].unitPower == tileStruct[1].unitPower)
            {
                tileStruct[1].unitPower = playerTwoRandom.Next(1, 4);
            }

            if (tileStruct[23].unitPower == tileStruct[1].unitPower)
            {
                tileStruct[1].unitPower = playerTwoRandom.Next(1, 4);
            }

            if (tileStruct[1].unitPower == tileStruct[11].unitPower)
            {
                tileStruct[11].unitPower = playerThreeRandom.Next(1, 4);
            }

            if (tileStruct[13].unitPower == tileStruct[11].unitPower)
            {
                tileStruct[11].unitPower = playerThreeRandom.Next(1, 4);
            }
            if (tileStruct[23].unitPower == tileStruct[11].unitPower)
            {
                tileStruct[11].unitPower = playerThreeRandom.Next(1, 4);
            }

            if (tileStruct[11].unitPower == tileStruct[23].unitPower)
            {
                tileStruct[23].unitPower = playerFourRandom.Next(1, 4);
            }

            if (tileStruct[1].unitPower == tileStruct[23].unitPower)
            {
                tileStruct[23].unitPower = playerFourRandom.Next(1, 4);
            }

            if (tileStruct[13].unitPower == tileStruct[23].unitPower)
            {
                tileStruct[23].unitPower = playerFourRandom.Next(1, 4);
            }
            #endregion
        }
    }
}
