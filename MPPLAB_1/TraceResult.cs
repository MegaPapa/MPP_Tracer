using System;

public class TraceResult {
    private double TracingTime;
    private String MethodName,ClassName;
    private int ParametersCount;

    public void setTime(double time) {
        this.TracingTime = time;
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
        return this.TracingTime;
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
