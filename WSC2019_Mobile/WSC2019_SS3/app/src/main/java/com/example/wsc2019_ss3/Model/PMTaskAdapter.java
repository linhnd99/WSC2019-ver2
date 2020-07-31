package com.example.wsc2019_ss3.Model;

import android.content.Context;
import android.graphics.Color;
import android.text.Layout;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.CheckBox;
import android.widget.TextView;

import com.example.wsc2019_ss3.R;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

import static android.content.ContentValues.TAG;

public class PMTaskAdapter extends BaseAdapter {
    Context context;
    int layout;
    ArrayList<PMTask> listPMTask;

    public PMTaskAdapter(Context context, int layout, ArrayList<PMTask> listPMTask) {
        this.context = context;
        this.layout = layout;
        this.listPMTask = listPMTask;
    }

    @Override
    public int getCount() {
        return listPMTask.size();
    }

    @Override
    public Object getItem(int i) {
        return listPMTask.get(i);
    }

    @Override
    public long getItemId(int i) {
        return listPMTask.get(i).getID();
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        if (view == null)
            view = LayoutInflater.from(viewGroup.getContext()).inflate(layout,viewGroup,false);

        TextView tvAsset,tvTaskName,tvScheduleType;
        CheckBox chkSelect;

        tvAsset = view.findViewById(R.id.tvAsset);
        tvTaskName = view.findViewById(R.id.tvTaskName);
        tvScheduleType = view.findViewById(R.id.tvScheduleType);
        chkSelect = view.findViewById(R.id.chkSelect);

        PMTask pmtask = listPMTask.get(i);

        tvAsset.setText(pmtask.getAssetSN() +" ** "+pmtask.getAssetName());
        tvTaskName.setText(pmtask.getTaskName());
        try {
            Date date = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss").parse(pmtask.getScheduleDate());
            tvScheduleType.setText(new SimpleDateFormat("dd/MM/yyyy").format(date));
        } catch (Exception ex)
        {
            Log.e(TAG, "getView: "+ex.getMessage());
        }
        chkSelect.setSelected(pmtask.getTaskDone());
        chkSelect.setBackgroundColor(Color.argb(1,0,255,0));
        return view;
    }
}

