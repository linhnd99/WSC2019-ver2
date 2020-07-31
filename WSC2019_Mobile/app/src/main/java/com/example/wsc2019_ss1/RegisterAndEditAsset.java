package com.example.wsc2019_ss1;

import androidx.annotation.NonNull;
import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.app.DatePickerDialog;
import android.app.ProgressDialog;
import android.os.Build;
import android.os.Bundle;
import android.os.StrictMode;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.Spinner;
import android.widget.TextView;

import com.android.volley.AuthFailureError;
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
import com.example.wsc2019_ss1.Model.Employee;
import com.example.wsc2019_ss1.Model.Location;
import com.google.android.material.snackbar.Snackbar;
import com.google.gson.Gson;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.lang.reflect.Method;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.ArrayList;
import java.util.Calendar;

import static com.example.wsc2019_ss1.Model.DEF.*;

public class RegisterAndEditAsset extends AppCompatActivity {

    EditText txtAssetName,txtAssetDescription,txtExpiredWarranty;
    Spinner spnDepartment, spnLocation, spnAssetGroup, spnAccountableParty;
    TextView tvAssetSN;
    Button btnSubmit,btnBack,btnCancel;

    ArrayList<Department> listDepartment;
    ArrayList<AssetGroup> listAssetGroup;
    ArrayList<Location> listLocation;
    ArrayList<Employee> listEmployee;
    ArrayList<Asset> listAsset;

    Calendar warranty;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register_and_edit_asset);
        getSupportActionBar().hide();

        AnhXa();

        warranty = Calendar.getInstance();

        LoadDataToView();

        txtExpiredWarranty.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View view, boolean b) {
                if (b)
                {
                    DatePickerDialog dialog = new DatePickerDialog(RegisterAndEditAsset.this, new DatePickerDialog.OnDateSetListener() {
                        @Override
                        public void onDateSet(DatePicker datePicker, int i, int i1, int i2) {
                            warranty.set(Calendar.YEAR,i);
                            warranty.set(Calendar.MONTH,i1);
                            warranty.set(Calendar.DAY_OF_MONTH,i2);
                            txtExpiredWarranty.setText(i2+"/"+i1+"/"+i);
                        }
                    },warranty.get(Calendar.YEAR),warranty.get(Calendar.MONTH),warranty.get(Calendar.DAY_OF_MONTH));
                    dialog.show();
                }
            }
        });


        spnDepartment.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                ComputeAssetSN();
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });
        spnAssetGroup.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                ComputeAssetSN();
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });

        btnBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                RegisterAndEditAsset.super.onBackPressed();
            }
        });
        btnCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                RegisterAndEditAsset.super.onBackPressed();
            }
        });
        btnSubmit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                boolean isExistsAssetName = false;
                Location selectedLocation = (Location) spnLocation.getSelectedItem();
                for (Asset asset : listAsset) {
                    if (txtAssetName.getText().toString().equals(asset.getAssetName()) && asset.getLocationID() == selectedLocation.getID()) {
                        isExistsAssetName = true;
                        break;
                    }
                }
                if (isExistsAssetName) {
                    Snackbar.make(findViewById(R.id.view), "This asset name is existed in this location", 500).show();
                    return;
                }

                final ProgressDialog progressDialog = new ProgressDialog(RegisterAndEditAsset.this);
                progressDialog.show();

                RequestQueue requestQueue = Volley.newRequestQueue(RegisterAndEditAsset.this);
                StringRequest addAssetRequest = new StringRequest(Request.Method.POST, DOMAIN + ADD_ASSET, new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        Log.d("TAG", response);
                        progressDialog.dismiss();
                        RegisterAndEditAsset.super.onBackPressed();
                    }
                }, new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        progressDialog.dismiss();
                        Snackbar.make(findViewById(R.id.view), "Can not post Asset to server", 0).show();
                        //Log.e("Error",error.getMessage());
                    }
                }) {
                    @Override
                    public byte[] getBody() throws AuthFailureError {

                        Department selectedDepartment = (Department) spnDepartment.getSelectedItem();
                        AssetGroup selectedAssetGroup = (AssetGroup) spnAssetGroup.getSelectedItem();
                        Employee selectedEmployee = (Employee) spnAccountableParty.getSelectedItem();
                        Location selectedLocation = (Location) spnLocation.getSelectedItem();

                        Asset asset = new Asset();
                        asset.setAssetSN(tvAssetSN.getText().toString());
                        asset.setAssetName(txtAssetName.getText().toString());
                        asset.setDepartmentID(selectedDepartment.getID());
                        asset.setLocationID(selectedLocation.getID());
                        asset.setEmployeeID(selectedEmployee.getID());
                        asset.setAssetGroupID(selectedAssetGroup.getID());
                        asset.setDescription(txtAssetDescription.getText().toString());
                        asset.setWarrantyDate(warranty.get(Calendar.YEAR));

                        byte[] bodyRequest = Asset.toJson(asset).getBytes();
                        Log.d("TAG", Asset.toJson(asset));
                        return bodyRequest;
                    }
                };
                requestQueue.add(addAssetRequest);
            }
        });
    }

    void AnhXa()
    {
        btnBack = findViewById(R.id.btnBack);
        txtAssetName = findViewById(R.id.txtAssetName);
        spnDepartment = findViewById(R.id.spnDepartment);
        spnLocation = findViewById(R.id.spnLocation);
        spnAssetGroup = findViewById(R.id.spnAssetGroup);
        spnAccountableParty = findViewById(R.id.spnAccountableParty);
        txtAssetDescription  = findViewById(R.id.txtAssetDescription);
        txtExpiredWarranty = findViewById(R.id.txtExpiredWarranty);
        tvAssetSN = findViewById(R.id.tvAssetSN);
        btnSubmit = findViewById(R.id.btnSubmit);
        btnCancel = findViewById(R.id.btnCancel);
    }

    void LoadDataToView()
    {
        RequestQueue requestQueue = Volley.newRequestQueue(RegisterAndEditAsset.this);
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
                        ArrayAdapter departmentAdapter = new ArrayAdapter(RegisterAndEditAsset.this, R.layout.support_simple_spinner_dropdown_item,listDepartment);
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
                        ArrayAdapter assetGroupAdapter = new ArrayAdapter(RegisterAndEditAsset.this, R.layout.support_simple_spinner_dropdown_item,listAssetGroup);
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

        StringRequest locationRequest = new StringRequest(Request.Method.POST, DOMAIN + GET_ALL_LOCATION, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                Gson gson = new Gson();
                ArrayList data = gson.fromJson(response,ArrayList.class);
                listLocation = new ArrayList<>();
                for (Object element : data)
                {
                    listLocation.add(Location.fromJson(gson.toJson(element)));
                }
                ArrayAdapter locationAdapter = new ArrayAdapter(RegisterAndEditAsset.this, R.layout.support_simple_spinner_dropdown_item,listLocation);
                spnLocation.setAdapter(locationAdapter);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.e("Error",error.getMessage());
            }
        });
        requestQueue.add(locationRequest);

        StringRequest employeeRequest = new StringRequest(1, DOMAIN + GET_ALL_EMPLOYEE, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                Gson gson = new Gson();
                ArrayList data = gson.fromJson(response,ArrayList.class);
                listEmployee = new ArrayList<>();
                for (Object element : data)
                {
                    listEmployee.add(Employee.fromJson(gson.toJson(element)));
                }
                ArrayAdapter employeeAdapter = new ArrayAdapter(RegisterAndEditAsset.this, R.layout.support_simple_spinner_dropdown_item,listEmployee);
                spnAccountableParty.setAdapter(employeeAdapter);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.e("Error",error.getMessage());
            }
        });
        requestQueue.add(employeeRequest);

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
                ComputeAssetSN();
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.e("Error",error.getMessage());
            }
        });
        requestQueue.add(assetRequest);
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


