package com.example.wsc2019_ss3;

import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
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
import com.example.wsc2019_ss3.Model.Asset;
import com.example.wsc2019_ss3.Model.PMTask;
import com.example.wsc2019_ss3.Model.PMTaskAdapter;
import com.example.wsc2019_ss3.Model.SharedData;
import com.example.wsc2019_ss3.Model.Task;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.gson.Gson;
import com.google.gson.internal.bind.ArrayTypeAdapter;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

import static com.example.wsc2019_ss3.Model.DEF.DOMAIN;
import static com.example.wsc2019_ss3.Model.DEF.GET_ALL_ASSET;
import static com.example.wsc2019_ss3.Model.DEF.GET_ALL_PM_TASK;
import static com.example.wsc2019_ss3.Model.DEF.GET_ALL_TASK;

public class MainActivity extends AppCompatActivity {

    EditText txtActiveDate;
    Calendar activeDate;
    ListView lvPMTask;
    FloatingActionButton btnAdd;
    Spinner spnAsset, spnTask;
    Button btnClearFilter;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        getSupportActionBar().hide();

        SharedData.sharedData = new SharedData();

        AnhXa();

        LoadDataToView();

        spnAsset.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                FilterData();
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });
        spnTask.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                FilterData();
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });
        txtActiveDate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                DatePickerDialog dialog = new DatePickerDialog(MainActivity.this, new DatePickerDialog.OnDateSetListener() {
                    @Override
                    public void onDateSet(DatePicker datePicker, int i, int i1, int i2) {
                        activeDate.set(Calendar.YEAR,i);
                        activeDate.set(Calendar.MONTH,i1);
                        activeDate.set(Calendar.DAY_OF_MONTH,i2);
                        txtActiveDate.setText(i2+"/"+i1+"/"+i);
                        FilterData();
                    }
                },activeDate.get(Calendar.YEAR),activeDate.get(Calendar.MONTH),activeDate.get(Calendar.DAY_OF_MONTH));
                dialog.show();
            }
        });

        btnClearFilter.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                spnAsset.setSelection(0);
                spnTask.setSelection(0);

                activeDate=Calendar.getInstance();
                txtActiveDate.setText("");

                PMTaskAdapter pmTaskAdapter = new PMTaskAdapter(MainActivity.this,R.layout.pm_task_cell,SharedData.sharedData.listPMTask);
                lvPMTask.setAdapter(pmTaskAdapter);
            }
        });

        btnAdd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(MainActivity.this,CreatePM.class);
                startActivity(intent);
            }
        });
    }

    void AnhXa()
    {
        txtActiveDate = findViewById(R.id.txtActiveDate);
        lvPMTask = findViewById(R.id.lvItem);
        spnAsset = findViewById(R.id.spnAssetName);
        spnTask = findViewById(R.id.spnTask);
        btnAdd = findViewById(R.id.btnAdd);
        btnClearFilter = findViewById(R.id.btnClearFilter);

        activeDate = Calendar.getInstance();
    }

    void LoadDataToView()
    {

        RequestQueue requestQueue = Volley.newRequestQueue(MainActivity.this);
        StringRequest assetRequest = new StringRequest(Request.Method.POST, DOMAIN + GET_ALL_ASSET, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                Gson gson = new Gson();
                ArrayList data = gson.fromJson(response,ArrayList.class);
                ArrayList res = new ArrayList();
                for (Object element : data) {
                    res.add(Asset.fromJson(gson.toJson(element)));
                }
                SharedData.sharedData.listAsset = res;
                ArrayAdapter assetAdapter = new ArrayAdapter(MainActivity.this,R.layout.support_simple_spinner_dropdown_item,res);
                spnAsset.setAdapter(assetAdapter);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.e("Error",error.getMessage());
            }
        });
        requestQueue.add(assetRequest);

        StringRequest taskRequest = new StringRequest(Request.Method.POST, DOMAIN + GET_ALL_TASK, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                Gson gson = new Gson();
                ArrayList data = gson.fromJson(response,ArrayList.class);
                ArrayList res = new ArrayList();
                for (Object element : data)
                    res.add(Task.fromJson(gson.toJson(element)));
                SharedData.sharedData.listTask = res;
                ArrayAdapter taskAdapter = new ArrayAdapter(MainActivity.this,R.layout.support_simple_spinner_dropdown_item,res);
                spnTask.setAdapter(taskAdapter);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.e("Error",error.getMessage());
            }
        });
        requestQueue.add(taskRequest);

        StringRequest pmtaskRequest = new StringRequest(Request.Method.POST, DOMAIN + GET_ALL_PM_TASK, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                Gson gson = new Gson();
                ArrayList data = gson.fromJson(response,ArrayList.class);
                ArrayList res = new ArrayList();
                for (Object element : data)
                    res.add(PMTask.fromJson(gson.toJson(element)));
                SharedData.sharedData.listPMTask = res;

                PMTaskAdapter pmTaskAdapter = new PMTaskAdapter(MainActivity.this,R.layout.pm_task_cell,res);
                lvPMTask.setAdapter(pmTaskAdapter);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Log.e("Error",error.getMessage());
            }
        });
        requestQueue.add(pmtaskRequest);
    }

    void FilterData()
    {
        ArrayList<PMTask> res = new ArrayList<>();
        for (PMTask element : SharedData.sharedData.listPMTask)
        {
            Date date;
            Calendar calendar = Calendar.getInstance();
            try {
                date = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss").parse(element.getScheduleDate());
                calendar.setTime(date);
                calendar.add(Calendar.DAY_OF_MONTH,4);
            } catch (Exception ex)
            {
                Log.e("Error",ex.getMessage());
            }
            if (calendar.before(activeDate))
            {
                Asset asset = (Asset) spnAsset.getSelectedItem();
                Task task = (Task) spnTask.getSelectedItem();

                if (element.getTaskID() == task.getID() && element.getAssetID() == asset.getID())
                    res.add(element);
            }
        }

        PMTaskAdapter pmTaskAdapter = new PMTaskAdapter(MainActivity.this,R.layout.pm_task_cell,res);
        lvPMTask.setAdapter(pmTaskAdapter);
    }
}
