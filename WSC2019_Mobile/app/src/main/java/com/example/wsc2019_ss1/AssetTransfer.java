package com.example.wsc2019_ss1;

import androidx.appcompat.app.AppCompatActivity;

import android.app.DownloadManager;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.wsc2019_ss1.Model.Asset;
import com.example.wsc2019_ss1.Model.AssetGroup;
import com.example.wsc2019_ss1.Model.Department;
import com.example.wsc2019_ss1.Model.Location;
import com.google.gson.Gson;

import java.util.ArrayList;

import static com.example.wsc2019_ss1.Model.DEF.*;

public class AssetTransfer extends AppCompatActivity {

    TextView tvAssetName,tvCurrentDepartment, tvAssetSN, tvNewAssetSN;
    Spinner spnDepartment, spnLocation;
    Button btnBack,btnSubmit,btnCancel;

    ArrayList<Department> listDepartment;
    ArrayList<Location> listLocation;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_asset_transfer);
        getSupportActionBar().hide();

        AnhXa();

        LoadDataToView();

        btnCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                AssetTransfer.super.finish();
            }
        });
        btnBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                AssetTransfer.super.finish();
            }
        });
    }

    void AnhXa(){
        tvAssetName = findViewById(R.id.tvAssetName);
        tvCurrentDepartment = findViewById(R.id.tvDepartmentName);
        tvAssetSN = findViewById(R.id.tvAssetSN);
        tvNewAssetSN = findViewById(R.id.tvNewAssetSN);
        spnDepartment = findViewById(R.id.spnDepartment);
        spnLocation = findViewById(R.id.spnLocation);
        btnBack = findViewById(R.id.btnBack);
        btnSubmit = findViewById(R.id.btnSubmit);
        btnCancel = findViewById(R.id.btnCancel);
    }

    void LoadDataToView()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(AssetTransfer.this);
        StringRequest departmentRequest = new StringRequest(Request.Method.POST, DOMAIN + GET_ALL_DEPARTMENT,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        Gson gson = new Gson();
                        ArrayList data = gson.fromJson(response,ArrayList.class);
                        listDepartment = new ArrayList<>();
                        for (Object element : data)
                        {
                            String test = gson.toJson(element);
                            listDepartment.add(Department.fromJson(test));
                        }
                        ArrayAdapter departmentAdapter = new ArrayAdapter(AssetTransfer.this,R.layout.support_simple_spinner_dropdown_item,listDepartment);
                        spnDepartment.setAdapter(departmentAdapter);
                    }
                },
                new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        Log.e("Error",error.getMessage());
                    }
                }
        );
        requestQueue.add(departmentRequest);

        StringRequest locationRequest = new StringRequest(Request.Method.POST, DOMAIN + GET_ALL_LOCATION, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                Gson gson = new Gson();
                ArrayList data = gson.fromJson(response,ArrayList.class);
                listLocation = new ArrayList<>();
                for (Object element : data)
                {
                    String test = gson.toJson(element);
                    listLocation.add(Location.fromJson(test));
                }
                ArrayAdapter locationAdapter = new ArrayAdapter(AssetTransfer.this,R.layout.support_simple_spinner_dropdown_item,listLocation);
                spnLocation.setAdapter(locationAdapter);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.e("Error",error.getMessage());
            }
        });
        requestQueue.add(locationRequest);

        StringRequest assetRequest = new StringRequest(Request.Method.POST, DOMAIN + GET_ALL_ASSET, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {

            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {

            }
        });
    }

    void ComputeAssetSN()
    {
        ArrayList<Asset> listFilter = new ArrayList<>();
        Department selectedDepartment = (Department) spnDepartment.getSelectedItem();
        AssetGroup selectedAssetGroup = (AssetGroup) spnAssetGroup.getSelectedItem();

        for (Asset asset : listAsset)
        {
            if (asset.getDepartmentID() == selectedDepartment.getID() && asset.getAssetGroupID() == selectedAssetGroup.getID())
            {
                listFilter.add(asset);
            }
        }

        int ma = 0;
        for (Asset asset : listFilter)
        {
            int x = Integer.parseInt(asset.getAssetSN().subSequence(asset.getAssetSN().length()-4,asset.getAssetSN().length()).toString());
            if (ma<x) ma = x;
        }
        String a="",b="",c="";
        if (selectedAssetGroup.getID()<10) b="0"+selectedAssetGroup.getID();
        else b=selectedAssetGroup.getID()+"";
        if (selectedDepartment.getID()<10) a="0"+selectedDepartment.getID();
        else a = selectedDepartment.getID()+"";
        c = (ma+1)+"";
        while (c.length()<4) c="0"+c;
        tvAssetSN.setText(a+"/"+b+"/"+c);
    }
}