package com.example.wsc2019_ss3.Model;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.example.wsc2019_ss3.R;

import java.util.ArrayList;

public class PMTask2Adapter extends BaseAdapter {

    Context context;
    int layout;
    ArrayList<PMTask> listPMTask;

    public PMTask2Adapter(Context context, int layout, ArrayList<PMTask> listPMTask) {
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
            view = LayoutInflater.from(context).inflate(layout,viewGroup,false);

        TextView txtTitle = view.findViewById(R.id.tvAssetName);
        txtTitle.setText(listPMTask.get(i).getAssetName());
        return view;
    }
}
