package com.example.wsc2019_ss3;

import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.wsc2019_ss3.Model.PMTask2Adapter;
import com.example.wsc2019_ss3.Model.ScheduleModel;
import com.example.wsc2019_ss3.Model.SharedData;
import com.google.gson.Gson;
import com.google.gson.internal.bind.ArrayTypeAdapter;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

import static com.example.wsc2019_ss3.Model.DEF.DOMAIN;
import static com.example.wsc2019_ss3.Model.DEF.GET_ALL_SCHEDULE_MODEL;

public class CreatePM extends AppCompatActivity {

    Spinner spnTask,spnAsset,spnScheduleModel;
    EditText txtStartDate,txtEndDate;
    ListView lvAsset;
    Button btnAdd, btnSubmit, btnCancel,btnBack;
    Calendar startDate, endDate;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_create_pm);
        getSupportActionBar().hide();

        AnhXa();

        LoadDataToView();

        btnBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                CreatePM.super.finish();
            }
        });
        btnCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                CreatePM.super.finish();
            }
        });
        txtStartDate.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View view, boolean b) {
                if (b) {
                    DatePickerDialog dialog = new DatePickerDialog(CreatePM.this, new DatePickerDialog.OnDateSetListener() {
                        @Override
                        public void onDateSet(DatePicker datePicker, int i, int i1, int i2) {
                            startDate.set(Calendar.YEAR,i);
                            startDate.set(Calendar.MONTH,i1);
                            startDate.set(Calendar.DAY_OF_MONTH,i2);
                            txtStartDate.setText(i2+"/"+i1+"/"+i);
                        }
                    }, startDate.get(Calendar.YEAR), startDate.get(Calendar.MONTH), startDate.get(Calendar.DAY_OF_MONTH));
                    dialog.show();
                }
            }
        });
        txtEndDate.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View view, boolean b) {
                if (b){
                    DatePickerDialog dialog = new DatePickerDialog(CreatePM.this, new DatePickerDialog.OnDateSetListener() {
                        @Override
                        public void onDateSet(DatePicker datePicker, int i, int i1, int i2) {
                            endDate.set(Calendar.YEAR,i);
                            endDate.set(Calendar.MONTH,i1);
                            endDate.set(Calendar.DAY_OF_MONTH,i2);
                            txtEndDate.setText(i2+"/"+i1+"/"+i);
                        }
                    }, endDate.get(Calendar.YEAR), endDate.get(Calendar.MONTH), endDate.get(Calendar.DAY_OF_MONTH));
                    dialog.show();
                }
            }
        });
        txtStartDate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                DatePickerDialog dialog = new DatePickerDialog(CreatePM.this, new DatePickerDialog.OnDateSetListener() {
                    @Override
                    public void onDateSet(DatePicker datePicker, int i, int i1, int i2) {
                        startDate.set(Calendar.YEAR,i);
                        startDate.set(Calendar.MONTH,i1);
                        startDate.set(Calendar.DAY_OF_MONTH,i2);
                        txtStartDate.setText(i2+"/"+i1+"/"+i);
                    }
                }, startDate.get(Calendar.YEAR), startDate.get(Calendar.MONTH), startDate.get(Calendar.DAY_OF_MONTH));
                dialog.show();
            }
        });
        txtEndDate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                DatePickerDialog dialog = new DatePickerDialog(CreatePM.this, new DatePickerDialog.OnDateSetListener() {
                    @Override
                    public void onDateSet(DatePicker datePicker, int i, int i1, int i2) {
                        endDate.set(Calendar.YEAR,i);
                        endDate.set(Calendar.MONTH,i1);
                        endDate.set(Calendar.DAY_OF_MONTH,i2);
                        txtEndDate.setText(i2+"/"+i1+"/"+i);
                    }
                }, endDate.get(Calendar.YEAR), endDate.get(Calendar.MONTH), endDate.get(Calendar.DAY_OF_MONTH));
                dialog.show();
            }
        });
    }

    void AnhXa()
    {
        btnBack = findViewById(R.id.btnBack);
        btnAdd = findViewById(R.id.btnAddToList);
        btnCancel = findViewById(R.id.btnCancel);
        btnSubmit = findViewById(R.id.btnSubmit);
        spnTask = findViewById(R.id.spnTask);
        spnAsset = findViewById(R.id.spnAsset);
        spnScheduleModel = findViewById(R.id.spnScheduleModel);
        txtStartDate = findViewById(R.id.txtStartDate);
        txtEndDate = findViewById(R.id.txtEndDate);
        lvAsset = findViewById(R.id.lvAsset);

        startDate = Calendar.getInstance();
        endDate = Calendar.getInstance();
    }

    void LoadDataToView()
    {
        ArrayAdapter taskAdapter = new ArrayAdapter(CreatePM.this,R.layout.support_simple_spinner_dropdown_item, SharedData.sharedData.listTask);
        spnTask.setAdapter(taskAdapter);

        ArrayAdapter assetAdapter = new ArrayAdapter(CreatePM.this,R.layout.support_simple_spinner_dropdown_item,SharedData.sharedData.listAsset);
        spnAsset.setAdapter(assetAdapter);

        PMTask2Adapter pmTask2Adapter = new PMTask2Adapter(CreatePM.this,R.layout.asset_cell,SharedData.sharedData.listPMTask);
        lvAsset.setAdapter(pmTask2Adapter);

        RequestQueue requestQueue = Volley.newRequestQueue(CreatePM.this);
        StringRequest scheduleModelRequest = new StringRequest(Request.Method.POST, DOMAIN + GET_ALL_SCHEDULE_MODEL, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                Gson gson = new Gson();
                ArrayList data = gson.fromJson(response,ArrayList.class);
                ArrayList<ScheduleModel> res=new ArrayList<>();
                for (Object element : data){
                    res.add(ScheduleModel.fromJson(gson.toJson(element)));
                }
                SharedData.sharedData.listScheduleModel = res;

                ArrayAdapter scheduleModelAdapter = new ArrayAdapter(CreatePM.this,R.layout.support_simple_spinner_dropdown_item,res);
                spnScheduleModel.setAdapter(scheduleModelAdapter);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.e("TAG", "onErrorResponse: "+ error.getMessage());
            }
        });
        requestQueue.add(scheduleModelRequest);
    }
}