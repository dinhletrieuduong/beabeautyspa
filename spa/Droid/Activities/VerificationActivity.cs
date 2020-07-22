
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using spa.View;
using spa.Presenter;
using Android.Views.InputMethods;
using System.Timers;

namespace spa.Droid
{
    [Activity(Label = "VerificationActivity")]
    public class VerificationActivity : Activity, IVerificationView
    {
        private VerificationPresenter presenter;
        private ImageView backBtn;
        private Button continueBtn;
        private TextView resendBtn, errorTxtView;
        private EditText editText_1, editText_2, editText_3, editText_4, editText_5;
        EditText[] editTexts;

        private bool dialogVisible;
        private Timer timer;
        private int mins, second = 10, miliseconds;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_verification);

            initView();

            var app = MainApplication.GetApplication(this);
            initPresenter(app);
            app.CurrentActivity = this;

            timer = new Timer();
            timer.Interval = 1; // 1 milliseconds
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

        }

        private void initPresenter(MainApplication app)
        {
            presenter = (VerificationPresenter)app.Presenter;
            presenter.SetView(this);
        }

        private void initView()
        {
            errorTxtView = (TextView)FindViewById(Resource.Id.errorTxtView);

            backBtn = (ImageView)FindViewById(Resource.Id.backBtn);
            backBtn.Click += delegate { BackBtn_Clicked(); };

            resendBtn = (TextView)FindViewById(Resource.Id.resendBtn);
            resendBtn.Text = second > 9 ? "Resend on 0" + mins + ":" + second : "Resend on 0" + mins + ":0" + second;
            resendBtn.Click += delegate { ResendBtn_Clicked(); };
            resendBtn.Clickable = false;

            continueBtn = (Button)FindViewById(Resource.Id.continueBtn);
            continueBtn.Click += delegate { ContinueBtn_Clicked(); };

            editText_1 = (EditText)FindViewById(Resource.Id.editText1);
            editText_2 = (EditText)FindViewById(Resource.Id.editText2);
            editText_3 = (EditText)FindViewById(Resource.Id.editText3);
            editText_4 = (EditText)FindViewById(Resource.Id.editText4);
            editText_5 = (EditText)FindViewById(Resource.Id.editText5);
            editTexts = new EditText[] { editText_1, editText_2, editText_3, editText_4, editText_5 };
            //editText_1.AfterTextChanged += delegate { ChangeBackgroundEditText(editText_1, editText_1, editText_2, false); };
            //editText_2.AfterTextChanged += delegate { ChangeBackgroundEditText(editText_1, editText_2, editText_3, false); };
            //editText_3.AfterTextChanged += delegate { ChangeBackgroundEditText(editText_2, editText_3, editText_4, false); };
            //editText_4.AfterTextChanged += delegate { ChangeBackgroundEditText(editText_3, editText_4, editText_5, false); };
            //editText_5.AfterTextChanged += delegate { ChangeBackgroundEditText(editText_4, editText_5, editText_5, true); };
            editText_1.AfterTextChanged += delegate { ChangeBackgroundEditTexts(editTexts, 0); };
            editText_2.AfterTextChanged += delegate { ChangeBackgroundEditTexts(editTexts, 1); };
            editText_3.AfterTextChanged += delegate { ChangeBackgroundEditTexts(editTexts, 2); };
            editText_4.AfterTextChanged += delegate { ChangeBackgroundEditTexts(editTexts, 3); };
            editText_5.AfterTextChanged += delegate { ChangeBackgroundEditTexts(editTexts, 4); };
        }
        private void BackBtn_Clicked()
        {
            presenter.GoToLogin();
        }

        private void ResendBtn_Clicked()
        {
            errorTxtView.Visibility = ViewStates.Invisible;
        }

        private void ContinueBtn_Clicked()
        {
            errorTxtView.Visibility = ViewStates.Visible;
            foreach (EditText editText in editTexts)
                presenter.UpdateOTP(editText.Text);
            presenter.Verification();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            miliseconds++;
            if (miliseconds >= 1000)
            {
                second--;
                miliseconds = 0;
            }
            if (second == 59)
            {
                mins++;
                second = 0;
            }
            RunOnUiThread(() =>
            {
                resendBtn.Text = second > 9 ? "Resend on 0" + mins + ":" + second : "Resend on 0" + mins + ":0" + second;
            });
            if (second == 0)
            {
                timer.Stop();
                timer = null;
                resendBtn.Clickable = true;
            }
        }

        private void ChangeBackgroundEditText(EditText preEdtTxt, EditText editText, EditText nextEdtTxt, bool isLast)
        {
            if (!string.IsNullOrEmpty(editText.Text))
            {
                if (editText.Text.Length > 1)
                {
                    nextEdtTxt.Text += editText.Text[1].ToString();
                    editText.Text = editText.Text[0].ToString();
                }
                editText.SetBackgroundResource(Resource.Drawable.EdittextBottomLine_2);
                if (!isLast)
                {
                    nextEdtTxt.RequestFocus();
                    nextEdtTxt.SetSelection(nextEdtTxt.Text.Length);
                }
            }
            else
            {
                editText.SetBackgroundResource(Resource.Drawable.EdittextBottomLine);
                preEdtTxt.RequestFocus();
                preEdtTxt.SetSelection(preEdtTxt.Text.Length);
            }
        }

        private void ChangeBackgroundEditTexts(EditText[] editTexts, int curPosition)
        {
            var curEditTxt = editTexts[curPosition];
            var nextEdtTxt = curPosition != editTexts.Length - 1 ? editTexts[curPosition + 1] : editTexts[curPosition];
            var preEdtTxt = curPosition != 0 ? editTexts[curPosition - 1] : editTexts[curPosition];
            if (!string.IsNullOrEmpty(curEditTxt.Text))
            {
                if (curEditTxt.Text.Length > 1)
                {
                    if (curPosition != editTexts.Length - 1)
                        nextEdtTxt.Text += curEditTxt.Text[1].ToString();
                    curEditTxt.Text = curEditTxt.Text[0].ToString();
                    curEditTxt.SetSelection(curEditTxt.Text.Length);
                }
                curEditTxt.SetBackgroundResource(Resource.Drawable.EdittextBottomLine_2);
                if (curPosition != editTexts.Length - 1)
                {
                    nextEdtTxt.RequestFocus();
                    nextEdtTxt.SetSelection(nextEdtTxt.Text.Length);
                }
                else
                {
                    InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                    imm.HideSoftInputFromWindow(curEditTxt.WindowToken, 0);
                }
            }
            else
            {
                curEditTxt.SetBackgroundResource(Resource.Drawable.EdittextBottomLine);
                preEdtTxt.RequestFocus();
                preEdtTxt.SetSelection(preEdtTxt.Text.Length);
            }
        }
        public override void OnBackPressed()
        {
            presenter.GoToLogin();
        }

        protected override void OnStop()
        {
            base.OnStop();
            Finish();
        }

        public bool IsPerformingAction { get; private set; }

        public void OnActionStarted()
        {
            IsPerformingAction = true;
        }

        public void OnActionFinished()
        {
            IsPerformingAction = false;
        }

        public bool IsNavigating { get; private set; }

        public void OnNavigationStarted()
        {
            IsNavigating = true;
        }

        public void OnInputValidated(bool isValid)
        {
            //continueBtn.Enabled = isValid;
        }

        public void OnVerificationFailed(string errorMessage)
        {
            if (!dialogVisible)
            {
                dialogVisible = true;

                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("Error")
                    .SetMessage(errorMessage)
                    .SetNeutralButton("OK", (s, e) =>
                    {
                        dialogVisible = false;
                        foreach (EditText editText in editTexts)
                            editText.Text = "";
                        editTexts[0].RequestFocus();
                    })
                    .Show();

            }
        }

    }
}
