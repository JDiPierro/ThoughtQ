using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThoughtQ.Data.util
{
    class InterObjComm
    {
        tQueue tQueue;
        MainWindow mainWin;

        InterObjComm(ref tQueue tQ, ref MainWindow mWin)
        {
            tQueue = tQ;
            mainWin = mWin;
        }


    }
}
