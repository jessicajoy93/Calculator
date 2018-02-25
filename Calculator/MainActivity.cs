using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Collections.Generic;
using Android.Nfc;
using Android.Util;

namespace Calculator
{
    [Activity(Label = "Calculator", MainLauncher = true)]
    public class MainActivity : Activity
    {
        // You need to create the same controls that you have in the Xml in the Activity
        private TextView txtNum1;
        private TextView txtNum2;
        private double Num1;
        private double Num2;
        private double Result;
        private Button btnPlus;
        private Button btnMinus;
        private Button btnMul;
        private Button btnDivide;
        private string tag;
        private string result;

        //make a list to hold the answers
        private List<string> AnswerList = new List<string>();
        //make a listview to tie into the one on the view
        private ListView lvAnswer;
        //make an adapter to tie the list to the listview
        private ArrayAdapter<string> AnswerAdapter;



        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.BMI);
            InitializeControls(); //just a method to hold the binding
        }

        //you need to bind the controls you just made in the Activity to the controls in the Xaml - this will only work AFTER you have built it as it needs to create the Resource first
        private void InitializeControls()
        {
            btnPlus = FindViewById<Button>(Resource.Id.btnplus);
            btnMinus = FindViewById<Button>(Resource.Id.btnminus);
            btnMul = FindViewById<Button>(Resource.Id.btnmul);
            btnDivide = FindViewById<Button>(Resource.Id.btndivide);
            txtNum1 = FindViewById<TextView>(Resource.Id.txtNum1);
            txtNum2 = FindViewById<TextView>(Resource.Id.txtNum2);
            //here we bind the btn we have made to a click event, which is just another method. (This can be inline but I like it this way to keep things simpler)
            //Type in the method name onBtnMul_Click then from lightbulb choose Create Method. This will create the 4 methods you need.

            btnPlus.Click += onBtnPlus_Click;
            btnMinus.Click += onBtnMinus_Click;
            btnMul.Click += onBtnMul_Click;
            btnDivide.Click += onBtnDivide_Click;

            lvAnswer = FindViewById<ListView>(Resource.Id.lvAnswer);
            ListViewAnswerUpdate();
        }

        private void ListViewAnswerUpdate()
        {
            //need an arrayadapter for the listview to tie it to the list of answerlist
            AnswerAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, AnswerList);

            //tie the adapter to the listview
            lvAnswer.Adapter = AnswerAdapter;

            //add the answer to the adapter NOT the list!!!
            AnswerAdapter.Add("Test");

            //create a click event for the listview (not used yet)
            //lvAnswer.ItemClick += OnListItemClick;
        }

        private void calculation()
        {
            Num1 = Convert.ToDouble(txtNum1.Text);
            Num2 = Convert.ToDouble(txtNum2.Text);

            if (tag == "Divide")
            {
                Result = Num1 / Num2;
                result = (Num1 + " / " + Num2 + " = " + Result).ToString();
            }
            else if (tag == "Multiply")
            {
                Result = Num1 * Num2;
                result = (Num1 + " * " + Num2 + " = " + Result).ToString();
            }
            else if (tag == "Minus")
            {
                Result = Num1 - Num2;
                result = (Num1 + " - " + Num2 + " = " + Result).ToString();
            }
            else if (tag == "Plus")
            {
                Result = Num1 + Num2;
                result = (Num1 + " + " + Num2 + " = " + Result).ToString();
            }
            Log.Info(tag, Num1.ToString());
            Log.Info(tag, Num2.ToString());
            Log.Info(tag, result);
            Toast.MakeText(this, "The Result is " + Result, ToastLength.Long).Show();
        }
        private void onBtnDivide_Click(object sender, EventArgs e)
        {
            tag = "Divide";
            calculation();

            //Num1 = Convert.ToDouble(txtNum1.Text);
            //Num2 = Convert.ToDouble(txtNum2.Text);
            //Result = Num1 / Num2;
            //string result = (Num1 + " / " + Num2 + " = " + Result).ToString();

            //Log.Info(tag, Num1.ToString());
            //Log.Info(tag, Num2.ToString());
            //Log.Info(tag, result);
            //Toast.MakeText(this, "The Result is " + Result, ToastLength.Long).Show();
        }

        private void onBtnMul_Click(object sender, EventArgs e)
        {
            tag = "Multiply";
            calculation();

            //Num1 = Convert.ToDouble(txtNum1.Text);
            //Num2 = Convert.ToDouble(txtNum2.Text);
            //Result = Num1 * Num2;
            //string result = (Num1 + " * " + Num2 + " = " + Result).ToString();

            //Log.Info(tag, Num1.ToString());
            //Log.Info(tag, Num2.ToString());
            //Log.Info(tag, result);
            //Toast.MakeText(this, "The Result is " + Result, ToastLength.Long).Show();
        }

        private void onBtnMinus_Click(object sender, EventArgs e)
        {
            tag = "Minus";
            calculation();

            //Num1 = Convert.ToDouble(txtNum1.Text);
            //Num2 = Convert.ToDouble(txtNum2.Text);
            //Result = Num1 - Num2;
            //string result = (Num1 + " - " + Num2 + " = " + Result).ToString();

            //Log.Info(tag, Num1.ToString());
            //Log.Info(tag, Num2.ToString());
            //Log.Info(tag, result);
            Toast.MakeText(this, "The Result is " + Result, ToastLength.Long).Show();
        }
        private void onBtnPlus_Click(object sender, EventArgs e)
        {
            tag = "Plus";
            calculation();

            //Num1 = Convert.ToDouble(txtNum1.Text);
            //Num2 = Convert.ToDouble(txtNum2.Text);
            //Result = Num1 + Num2;
            //string result = (Num1 + " + " + Num2 + " = " + Result).ToString();

            //Log.Info(tag, Num1.ToString());
            //Log.Info(tag, Num2.ToString());
            //Log.Info(tag, result);
            //Toast.MakeText(this, "The Result is " + Result, ToastLength.Long).Show();
        }
    }
}

