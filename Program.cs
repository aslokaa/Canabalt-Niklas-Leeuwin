using System;

/**Niklas Leeuwin 50074205
 * GPA tentamen 2020 
 * Canabalt: Waluigi edition
 * Made using the centipede code as start
 * 
 **/



namespace Centipede
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Canabalt())
                game.Run();
        }
    }
#endif
}
