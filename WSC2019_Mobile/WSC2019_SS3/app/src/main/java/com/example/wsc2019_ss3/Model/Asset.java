package com.example.wsc2019_ss3.Model;

import com.google.gson.Gson;
import com.google.gson.annotations.SerializedName;

public class Asset {
    @SerializedName("ID")
    int ID;
    @SerializedName("AssetSN")
    String AssetSN;
    @SerializedName("AssetName")
    String AssetName;
    @SerializedName("Description")
    String Description;
    @SerializedName("WarrantyDate")
    int WarrantyDate;

    public static Asset fromJson(String json)
    {
        Gson gson = new Gson();
        return gson.fromJson(json,Asset.class);
    }

    public static String toJson(Asset asset)
    {
        Gson gson = new Gson();
        return gson.toJson(asset);
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

    @Override
    public String toString() {
        return AssetName;
    }
}
