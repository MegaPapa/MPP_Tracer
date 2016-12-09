using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Threading;

public class Tracer : ITracer {

    private static volatile Tracer instance;
    private static readonly Object threadLock = new Object();
    //private long startTime,endTime;
    private Stack traceStack = new Stack();
    public static volatile List<TraceResult> resultList = new List<TraceResult>();
    public static volatile int firstLevel = 0,thirdLevel = 0;

    public int getLVL() {
        return thirdLevel;
    }

    public TraceResult gettr() {
        return null;
    }

    public List<TraceResult> getTR() {
        return resultList;
    }

    public void IncrementCount() {
        lock (threadLock) {
            firstLevel++;
        }
    }

    //------------------------------------------------

    public static Tracer getInstance() {
        
        if (instance == null) {

            lock (threadLock) {
                if (instance == null)
                    instance = new Tracer();
            }

        }
        return instance;
    }

	public Tracer()	{
        
	}


    public void StartTrace() {

       TraceResult traceResult = new TraceResult();
       traceResult.setStartTime(DateTime.Now.Ticks / 10000);
       //Thread.CurrentThread.ManagedThreadId;
       lock (threadLock) {
            StackTrace st = new StackTrace(true);
            StackFrame sf = st.GetFrame(1);
            traceResult.setMethodName(sf.GetMethod().Name);
            traceResult.setClassName(sf.GetMethod().DeclaringType.ToString());
            traceResult.setParametersCount(sf.GetMethod().GetParameters().Length);
            traceStack.Push(traceResult);

            //test out
            /*Console.WriteLine(traceResult.getMethodName());
            Console.WriteLine(traceResult.getClassName());*/
            //Console.WriteLine(traceResult.getParametersCount());
            
        }
    }

    public void StopTrace() {

        lock (threadLock) {
            TraceResult tmpResult = new TraceResult();
            tmpResult = (TraceResult)traceStack.Pop();
            tmpResult.setEndTime(DateTime.Now.Ticks / 10000);
            tmpResult.setTraceTime();
            traceStack.Push(tmpResult);
        }
    }

    public TraceResult GetTraceResult() {
        lock (threadLock) {
            if (traceStack.Count != 1) {
                if (traceStack.Count == 3)
                    thirdLevel++;
                TraceResult internalTmpResult = new TraceResult();
                TraceResult externalTmpResult = new TraceResult();
                internalTmpResult = (TraceResult)traceStack.Pop();
                externalTmpResult = (TraceResult)traceStack.Pop();
                externalTmpResult.addInternalResult(internalTmpResult);
                traceStack.Push(externalTmpResult);
            }
            else {


                TraceResult tmpResult = new TraceResult();
                tmpResult = (TraceResult)traceStack.Pop();
                resultList.Add(tmpResult);
                IncrementCount();

            }
            return null;
        }
    }
}
