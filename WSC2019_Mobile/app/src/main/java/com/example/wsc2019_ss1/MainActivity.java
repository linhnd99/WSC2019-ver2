package com.example.wsc2019_ss1;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.content.res.Configuration;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.wsc2019_ss1.Adapter.AssetAdapter;
import com.example.wsc2019_ss1.Model.Asset;
import com.example.wsc2019_ss1.Model.AssetGroup;
import com.example.wsc2019_ss1.Model.Department;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.Calendar;

import static com.example.wsc2019_ss1.Model.DEF.*;

public class MainActivity extends AppCompatActivity {


    Calendar startDate,endDate;
    Spinner spnDepartment;
    Spinner spnAssetGroup;
    EditText txtStartDate;
    EditText txtEndDate, txtSearch;
    ListView lvAsset;
    FloatingActionButton btnAdd;
    ImageButton btnSearch;
    TextView tvResult;

    ArrayList<Asset> listAsset;
    ArrayList<Department> listDepartment;
    ArrayList<AssetGroup> listAssetGroup;

    @Override
    public void onConfigurationChanged(Configuration newConfig) {
        super.onConfigurationChanged(newConfig);
        SetOrientationScreen(newConfig);
    }

    void SetOrientationScreen(Configuration config)
    {
        if (config.orientation == getResources().getConfiguration().ORIENTATION_PORTRAIT) {
            setContentView(R.layout.activity_main);

            AnhXa();

            LoadDataToView(1);

            DatePicker();

            btnSearch.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    String str = txtSearch.getText().toString();
                    ArrayList<Asset> listFilter = new ArrayList<>();
                    Department departmentSelected = (Department) spnDepartment.getSelectedItem();
                    AssetGroup assetGroupSelected = (AssetGroup) spnAssetGroup.getSelectedItem();
                    for (Asset asset : listAsset)
                    {
                        boolean check1=false, check2=false;
                        if (str.trim().length()!=0)
                            if (asset.getAssetSN().toUpperCase().contains(str.toUpperCase()) || asset.getAssetName().toUpperCase().contains((str.toUpperCase())))
                                check1=true;
                            else;
                        else check1=true;
                        if (asset.getAssetGroupID() == assetGroupSelected.getID() && asset.getDepartmentID() == departmentSelected.getID())
                            check2=true;
                        if (check1 && check2)
                        {
                            listFilter.add(asset);
                        }
                    }
                    AssetAdapter assetAdapter = new AssetAdapter(MainActivity.this,R.layout.asset_cell, listFilter);
                    lvAsset.setAdapter(assetAdapter);
                    tvResult.setText(listFilter.size() + " assets from "+listAsset.size());
                }
            });
        }
        else
        {
            setContentView(R.layout.main_activity_landscape);

            AnhXa2();

            LoadDataToView(2);
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        SetOrientationScreen(MainActivity.this.getResources().getConfiguration());
    }

    void AnhXa()
    {
        spnDepartment = findViewById(R.id.spnDepartment);
        spnAssetGroup = findViewById(R.id.spnAssetGroup);
        txtStartDate = findViewById(R.id.txtStartDate);
        txtEndDate = findViewById(R.id.txtEndDate);
        txtSearch = findViewById(R.id.txtSearch);
        lvAsset = findViewById(R.id.lvAsset);
        btnAdd = findViewById(R.id.btnAdd);
        btnSearch = findViewById(R.id.btnSearch);
        tvResult = findViewById(R.id.tvResult);
    }
    void AnhXa2()
    {
        lvAsset = findViewById(R.id.lvAsset);
        btnAdd = findViewById(R.id.btnAdd);
    }

    void LoadDataToView(int sel)
    {
        RequestQueue requestQueue = Volley.newRequestQueue(MainActivity.this);
        if (sel==1)
        {
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
                            ArrayAdapter departmentAdapter = new ArrayAdapter(MainActivity.this,R.layout.support_simple_spinner_dropdown_item,listDepartment);
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

            StringRequest assetGroupRequest = new StringRequest(Request.Method.POST, DOMAIN + GET_ALL_ASSETGROUP,
                    new Response.Listener<String>() {
                        @Override
                        public void onResponse(String response) {
                            Gson gson = new Gson();
                            ArrayList data = gson.fromJson(response,ArrayList.class);
                            listAssetGroup = new ArrayList<>();
                            for (Object element : data)
                            {
                                listAssetGroup.add(AssetGroup.fromJson(gson.toJson(element)));
                            }
                            ArrayAdapter assetGroupAdapter = new ArrayAdapter(MainActivity.this,R.layout.support_simple_spinner_dropdown_item,listAssetGroup);
                            spnAssetGroup.setAdapter(assetGroupAdapter);
                        }
                    },
                    new Response.ErrorListener() {
                        @Override
                        public void onErrorResponse(VolleyError error) {
                            Log.e("Error",error.getMessage());
                        }
                    }
            );
            requestQueue.add(assetGroupRequest);
            StringRequest assetRequest = new StringRequest(Request.Method.POST, DOMAIN + GET_ALL_ASSET, new Response.Listener<String>() {
                @Override
                public void onResponse(String response) {
                    Gson gson = new Gson();
                    ArrayList data = gson.fromJson(response,ArrayList.class);
                    listAsset = new ArrayList<>();
                    for (Object element : data)
                    {
                        listAsset.add(Asset.fromJson(gson.toJson(element)));
                    }
                    AssetAdapter assetAdapter = new AssetAdapter(MainActivity.this,R.layout.asset_cell,listAsset);
                    lvAsset.setAdapter(assetAdapter);
                    ((TextView) findViewById(R.id.tvResult)).setText(listAsset.size() + " assets from "+listAsset.size());
                }
            }, new Response.ErrorListener() {
                @Override
                public void onErrorResponse(VolleyError error) {
                    Log.e("Error",error.getMessage());
                }
            });
            requestQueue.add(assetRequest);
        }
        else
        {
            StringRequest assetRequest = new StringRequest(Request.Method.POST, DOMAIN + GET_ALL_ASSET, new Response.Listener<String>() {
                @Override
                public void onResponse(String response) {
                    Gson gson = new Gson();
                    ArrayList data = gson.fromJson(response,ArrayList.class);
                    listAsset = new ArrayList<>();
                    for (Object element : data)
                    {
                        listAsset.add(Asset.fromJson(gson.toJson(element)));
                    }
                    AssetAdapter assetAdapter = new AssetAdapter(MainActivity.this,R.layout.asset_cell_landscape,listAsset);
                    lvAsset.setAdapter(assetAdapter);
                }
            }, new Response.ErrorListener() {
                @Override
                public void onErrorResponse(VolleyError error) {
                    Log.e("Error",error.getMessage());
                }
            });
            requestQueue.add(assetRequest);
        }


    }

    void DatePicker()
    {
        startDate = Calendar.getInstance();
        endDate = Calendar.getInstance();

        txtStartDate.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View view, boolean b) {
                if (b){
                    DatePickerDialog dialog = new DatePickerDialog(MainActivity.this, new DatePickerDialog.OnDateSetListener() {
                        @Override
                        public void onDateSet(DatePicker datePicker, int i, int i1, int i2) {
                            startDate.set(Calendar.YEAR,i);
                            startDate.set(Calendar.MONTH,i1);
                            startDate.set(Calendar.DAY_OF_MONTH,i2);
                            txtStartDate.setText(i2+"/"+i1+"/"+i);
                        }
                    }, startDate.get(Calendar.YEAR),startDate.get(Calendar.MONTH),startDate.get(Calendar.DAY_OF_MONTH));
                    dialog.show();
                }
            }
        });
        txtEndDate.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View view, boolean b) {
                if (b){
                    DatePickerDialog dialog = new DatePickerDialog(MainActivity.this, new DatePickerDialog.OnDateSetListener() {
                        @Override
                        public void onDateSet(DatePicker datePicker, int i, int i1, int i2) {
                            endDate.set(Calendar.YEAR,i);
                            endDate.set(Calendar.MONTH,i1);
                            endDate.set(Calendar.DAY_OF_MONTH,i2);
                            txtEndDate.setText(i2+"/"+i1+"/"+i);
                        }
                    }, endDate.get(Calendar.YEAR),endDate.get(Calendar.MONTH),endDate.get(Calendar.DAY_OF_MONTH));
                    dialog.show();
                }
            }
        });

    }
}