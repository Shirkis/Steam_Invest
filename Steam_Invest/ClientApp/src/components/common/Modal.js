import React from 'react'
import {
  withStyles,
  Dialog,
  DialogContent,
  DialogTitle,
  IconButton,
  Icon,
  DialogActions,
  Grid
} from '@material-ui/core'

const styles = theme => ({
  close: {
    top: 10,
    right: 10,
    position: 'absolute'
  },
  paper: {
    minWidth: 280
  },
  dtitle: {
    paddingRight: 40
  }
})

const ModalWrapped = props => {
  let classes = { paper: props.classes.paper, ...props.classes }
  return (
    <Dialog open={props.open} classes={classes} onClose={props.requestClose}>
      <DialogTitle>
        <div className={props.classes.dtitle}>{props.title}</div>
      </DialogTitle>
      {props.marginlessContent ? (
        <div>{props.children}</div>
      ) : (
        <DialogContent>{props.children}</DialogContent>
      )}
      {(props.primary || props.secondary) && (
        <DialogActions style={{ padding: '8px 20px' }}>
          <Grid container spacing={16}>
            <Grid item xs />
            <Grid item>{props.secondary}</Grid>
            <Grid item>{props.primary}</Grid>
          </Grid>
        </DialogActions>
      )}
      <IconButton onClick={props.requestClose} className={props.classes.close}>
        <Icon>clear</Icon>
      </IconButton>
    </Dialog>
  )
}

export default withStyles(styles)(ModalWrapped)