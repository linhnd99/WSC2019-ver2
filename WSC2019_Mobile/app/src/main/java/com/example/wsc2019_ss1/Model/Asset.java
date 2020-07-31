package com.example.wsc2019_ss1.Model;

import com.google.gson.Gson;
import com.google.gson.annotations.SerializedName;

public class Asset {
    @SerializedName("ID")
    int ID;
    @SerializedName("AssetSN")
    String AssetSN;
    @SerializedName("AssetName")
    String AssetName;
    @SerializedName("DepartmentLocationID")
    int DepartmentLocationID;
    @SerializedName("EmployeeID")
    int EmployeeID;
    @SerializedName("AssetGroupID")
    int AssetGroupID;
    @SerializedName("Description")
    String Description;
    @SerializedName("WarrantyDate")
    int WarrantyDate;
    @SerializedName("DepartmentID")
    int DepartmentID;
    @SerializedName("DepartmentName")
    String DepartmentName;
    @SerializedName("LocationID")
    int LocationID;
    @SerializedName("LocationName")
    String LocationName;

    public int getLocationID() {
        return LocationID;
    }

    public Asset() {
    }

    public void setLocationID(int locationID) {
        LocationID = locationID;
    }

    public String getLocationName() {
        return LocationName;
    }

    public void setLocationName(String locationName) {
        LocationName = locationName;
    }

    public int getDepartmentID() {
        return DepartmentID;
    }

    public void setDepartmentID(int departmentID) {
        DepartmentID = departmentID;
    }

    public String getDepartmentName() {
        return DepartmentName;
    }

    public void setDepartmentName(String departmentName) {
        DepartmentName = departmentName;
    }

    @Override
    public String toString() {
        return this.AssetName;
    }

    public static Asset fromJson(String json){
        Gson gson = new Gson();
        return gson.fromJson(json, Asset.class);
    }
    public static String toJson(Asset asset){
        Gson gson = new Gson();
        return gson.toJson(asset);
    }

    public Asset(int ID, String assetSN, String assetName, int departmentLocationID, int employeeID, int assetGroupID, String description, int warrantyDate) {
        this.ID = ID;
        AssetSN = assetSN;
        AssetName = assetName;
        DepartmentLocationID = departmentLocationID;
        EmployeeID = employeeID;
        AssetGroupID = assetGroupID;
        Description = description;
        WarrantyDate = warrantyDate;
    }

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public String getAssetSN() {
        return AssetSN;
    }

    public void setAssetSN(String assetSN) {
        AssetSN = assetSN;
    }

    public String getAssetName() {
        return AssetName;
    }

    public void setAssetName(String assetName) {
        AssetName = assetName;
    }

    public int getDepartmentLocationID() {
        return DepartmentLocationID;
    }

    public void setDepartmentLocationID(int departmentLocationID) {
        DepartmentLocationID = departmentLocationID;
    }

    public int getEmployeeID() {
        return EmployeeID;
    }

    public void setEmployeeID(int employeeID) {
        EmployeeID = employeeID;
    }

    public int getAssetGroupID() {
        return AssetGroupID;
    }

    public void setAssetGroupID(int assetGroupID) {
        AssetGroupID = assetGroupID;
    }

    public String getDescription() {
        return Description;
    }

    public void setDescription(String description) {
        Description = description;
    }

    public int getWarrantyDate() {
        return WarrantyDate;
    }

    public void setWarrantyDate(int warrantyDate) {
        WarrantyDate = warrantyDate;
    }
}
