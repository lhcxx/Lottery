using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LotteryBuz;

namespace Lottery.Actions
{
    public abstract class BaseAction
    {
        protected readonly Form _baseForm;
        protected FrmStart _processForm;
        private Form _msgForm;
        private bool _actionPause;
        protected ProgressController _processController;

        protected BaseAction(){
            _processController = new ProgressController();
            _processController.MessageChanged += OnControllerMessageChanged;
        }

        protected BaseAction(Form baseForm) : this(){
            _baseForm = baseForm;
        }

        private void OnControllerMessageChanged(string msg){
            ProcessForm.ShowMessage(msg, _processController.CanCancel);
        }

        public FrmStart ProcessForm{
            get{
                if (_processForm == null){
                    _processForm = new FrmStart();
                    _processForm.CancelClick += OnCancelClick;
                    _processForm.HandleCreated += OnProgressFormCreated;
                }
                return _processForm;
            }
        }

        private void OnCancelClick(){
            _processController.CanCancel = true;
        }

        private void OnProgressFormCreated(object sender, EventArgs e){
            Thread thread = new Thread(RunActionAsync);
            thread.Start();
        }

        public virtual void Run(){}

        public void RunInProgress(){
            if(_baseForm != null){
                ProcessForm.ShowDialog(_baseForm);
            }
            else{
                ProcessForm.ShowDialog();
            }
        }
        private void RunActionAsync(){
            try{
                Run();
                Thread.Sleep(2000);
                ProcessForm.CloseForm();
            }
            catch (Exception e){
                ProcessForm.ShowError(e);
           //     _log.Error("Run action error: ",e);
            }
        }

        protected void CallUIEvents(Action eventHandler){
            if(ProcessForm.InvokeRequired){
                ProcessForm.Invoke(eventHandler);
            }
            else{
                eventHandler();
            }
        }

        protected void CallAction(BaseAction action){
            action._processForm = ProcessForm;
            action.Run();
        }

        protected void ShowMessageForm(Form form){
            _actionPause = true;
            _msgForm = form;
            _msgForm.Closed += OnMessageFormClosed;
            ProcessForm.Invoke(new Action(()=>_msgForm.ShowDialog(ProcessForm)));
        }

        private void OnMessageFormClosed(object sender, EventArgs e){
            _actionPause = false;
            _processController.CanCancel = false;
        }
    }
}

