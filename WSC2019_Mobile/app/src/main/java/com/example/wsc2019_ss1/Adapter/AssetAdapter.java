package com.example.wsc2019_ss1.Adapter;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.TextView;

import com.example.wsc2019_ss1.Model.*;
import com.example.wsc2019_ss1.R;
import com.example.wsc2019_ss1.RegisterAndEditAsset;

import java.util.ArrayList;


public class AssetAdapter extends BaseAdapter {
    Context context;
    int layout;
    ArrayList<Asset> listAsset;
    Callback delegate;
    int index;

    public AssetAdapter(Context context, int layout, ArrayList<Asset> listAsset, Callback delegate) {
        this.context = context;
        this.layout = layout;
        this.listAsset = listAsset;
        this.delegate=delegate;
    }

    @Override
    public int getCount() {
        return listAsset.size();
    }

    @Override
    public Object getItem(int i) {
        return listAsset.get(i);
    }

    @Override
    public long getItemId(int i) {
        return listAsset.get(i).getID();
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        if (view == null)
            view = LayoutInflater.from(viewGroup.getContext()).inflate(layout,viewGroup,false);
        index = i;
        if (layout == R.layout.asset_cell){
            TextView tvAssetName,tvAssetSN,tvDepartmentName;
            tvAssetName = view.findViewById(R.id.tvAssetName);
            tvAssetSN = view.findViewById(R.id.tvAssetSN);
            tvDepartmentName = view.findViewById(R.id.tvDepartmentName);

            tvAssetName.setText(listAsset.get(i).getAssetName());
            tvAssetSN.setText(listAsset.get(i).getAssetSN());
            tvDepartmentName.setText(listAsset.get(i).getDepartmentName());

            ImageButton btnEdit,btnExit, btnOption;
            btnEdit = view.findViewById(R.id.btnEdit);
            btnExit = view.findViewById(R.id.btnExit);
            btnOption = view.findViewById(R.id.btnOption);

            btnEdit.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    delegate.StartRegisterAndEditAsset("edit",listAsset.get(index));
                }
            });
            btnExit.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    SharedData.sharedData.asset = listAsset.get(index);
                    delegate.StartAssetTransfer();
                }
            });
        }
        else if (layout == R.layout.asset_cell_landscape)
        {
            ((TextView)view.findViewById(R.id.tvAssetSN)).setText(listAsset.get(i).getAssetSN());
            ((TextView)view.findViewById(R.id.tvAssetName)).setText(listAsset.get(i).getAssetName());
        }

        return view;
    }
}
