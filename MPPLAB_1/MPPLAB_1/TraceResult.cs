using System;
using System.Collections.Generic;
using System.Xml.Serialization;

public class TraceResult {
    //[Serializable]
    
    /*public double TracingTime {
        get { return TracingTime; }
        set { TracingTime = value; }
    }
    public String MethodName {
        get { return MethodName; }
        set { MethodName = value; }
    }
    public String ClassName {
        get { return ClassName; }
        set { ClassName = value; }
    }
    public int ParametersCount {
        get { return ParametersCount; }
        set { ParametersCount = value; }
    }*/

    public List<TraceResult> internalResults;
    [XmlAttribute("methodName")]
    public String MethodName;
    [XmlAttribute("className")]
    public String ClassName;
    [XmlAttribute("parametersCount")]
    public int ParametersCount;
    private long startTracing, 
        endTracing;
    [XmlAttribute("tracingTime")]
    public long tracingTime;

    public TraceResult() {
        internalResults = new List<TraceResult>();
    }

    public void addInternalResult(TraceResult result) {
        internalResults.Add(result);
    }

    public void setStartTime(long time) {
        this.startTracing = time;
    }

    public void setEndTime(long time) {
        this.endTracing = time;
    }

    public void setTraceTime() {
        this.tracingTime = this.endTracing - this.startTracing;
    }

    public void setMethodName(String name) {
        this.MethodName = name;
    }

    public void setClassName(String name) {
        this.ClassName = name;
    }

    public void setParametersCount(int count) {
        this.ParametersCount = count;
    }

    public double getTime() {
        return this.tracingTime;
    }

    public String getMethodName() {
        return this.MethodName;
    }

    public String getClassName() {
        return this.ClassName;
    }

    public int getParametersCount(){
        return this.ParametersCount;
    }
}
