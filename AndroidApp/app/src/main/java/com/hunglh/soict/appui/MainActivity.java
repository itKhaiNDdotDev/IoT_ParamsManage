package com.hunglh.soict.appui;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.material.button.MaterialButton;


public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        TextView username = (TextView) findViewById(R.id.username);
        TextView password = (TextView) findViewById(R.id.password);

        MaterialButton btnLogin = (MaterialButton) findViewById(R.id.btnLogin);

        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (username.getText().toString().equals("hunghehe")
                        && password.getText().toString().equals("admin")) {
                    Toast.makeText(MainActivity.this, "LOGIN SUCCESS!", Toast.LENGTH_SHORT).show();
                }
                else Toast.makeText(MainActivity.this, "Incorrect info", Toast.LENGTH_SHORT).show();
            }
        });
    }
}