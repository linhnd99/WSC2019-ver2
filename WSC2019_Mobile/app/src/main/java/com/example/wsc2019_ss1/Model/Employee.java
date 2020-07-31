package com.example.wsc2019_ss1.Model;

import com.google.gson.Gson;
import com.google.gson.annotations.SerializedName;

public class Employee {
    @SerializedName("ID")
    int ID;
    @SerializedName("FirstName")
    String FirstName;
    @SerializedName("LastName")
    String LastName;
    @SerializedName("Phone")
    String Phone;

    public static Employee fromJson(String json)
    {
        Gson gson = new Gson();
        return gson.fromJson(json,Employee.class);
    }
    public String toJson(Employee employee)
    {
        Gson gson = new Gson();
        return gson.toJson(employee);
    }

    public Employee(int ID, String firstName, String lastName, String phone) {
        this.ID = ID;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }

    public Employee() { }



    @Override
    public String toString() {
        return FirstName+" "+LastName;
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public String getFirstName() {
        return FirstName;
    }

    public void setFirstName(String firstName) {
        FirstName = firstName;
    }

    public String getLastName() {
        return LastName;
    }

    public void setLastName(String lastName) {
        LastName = lastName;
    }

    public String getPhone() {
        return Phone;
    }

    public void setPhone(String phone) {
        Phone = phone;
    }
}
