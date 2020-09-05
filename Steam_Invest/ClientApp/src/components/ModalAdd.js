import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import {Table, Grid,Paper, TableContainer, TableHead, TableRow, TableCell, TableBody, InputLabel, Select, MenuItem } from "@material-ui/core";
export default function ModalAdd() {
  const [open, setOpen] = React.useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div>
      <Button variant="outlined" color="primary" onClick={handleClickOpen}>
        add
      </Button>
      <Dialog open={open} onClose={handleClose} aria-labelledby="form-dialog-title">
        <DialogTitle id="form-dialog-title">Добавление</DialogTitle>
        <DialogContent>
          <Select>
            
            <MenuItem value={10}>Dota 2</MenuItem>
            <MenuItem value={10}>Cs go</MenuItem>
          </Select>
          <TextField autoFocus margin="dense" id="itemName" label="Название" type="string" fullWidth/>
          <TextField autoFocus margin="dense" id="buyPrice" label="Начальная стоимость" type="number" fullWidth/>
          <TextField autoFocus margin="none" id="buyDate" label="Дата покупки" type="date" fullWidth/>

        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} color="primary">
            Отменить
          </Button>
          <Button onClick={handleClose} color="primary">
            Добавить
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}
