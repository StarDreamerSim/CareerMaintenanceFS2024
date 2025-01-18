namespace CareerMaintenance
{
    public class CareerPixelPos
    {
        public int mPosX;
        public int mPosY;
        public CareerPixelPos(int iPosX, int iPosY)
        {
            mPosX = iPosX;
            mPosY = iPosY;
        }
    }
    public class CareerPixelColor
    {
        public int mRed;
        public int mGreen;
        public int mBlue;

        public CareerPixelColor(int iRed, int iGreen, int iBlue)
        {
            mRed = iRed;
            mGreen = iGreen;
            mBlue = iBlue;
        }
    }

    public class CareerPosAndColor
    {
        public CareerPixelPos mPos;
        public CareerPixelColor mColor;
        public CareerPosAndColor(int iPosX, int iPosY, int iRed, int iGreen, int iBlue)
        {
            mPos = new CareerPixelPos(iPosX, iPosY);
            mColor = new CareerPixelColor(iRed, iGreen, iBlue);
        }
    }

}
