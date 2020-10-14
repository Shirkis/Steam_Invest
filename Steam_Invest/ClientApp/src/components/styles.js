import teal from 'material-ui/colors/teal'

const styles = theme => ({
  paperCart: {
    [theme.breakpoints.up('md')]: {
      paddingLeft: 40,
      paddingRight: 40
    },
    [theme.breakpoints.down('md')]: {
      paddingLeft: 16,
      paddingRight: 16
    },
    paddingTop: 16,
    paddingBottom: 40
  },
  link: {
    lineHeight: 1.6,
    color: 'rgba(36,36,33,1);',
    transition: 'all 0.4s',
    borderBottom: ' 1px solid rgba(36,36,33,0.2)',
    fontSize: 15,
    '&:hover': {
      transition: 'all 0.4s',
      borderBottomColor: 'rgba(36,36,33,.5)'
    },
    padding: 0,
    cursor: 'pointer'
  },
  price: {
    fontSize: 19,
    fontWeight: 'bold',
    marginRight: 28
  },
  icon: {
    color: 'rgba(36,36,33,.54)'
  },
  borderdashed: {
    borderBottom: '1px dashed rgba(36,36,33,0.2)'
  },
  itogo: {
    fontSize: 13,
    fontWeight: 'normal',
    marginRight: 9
  },
  searchInput: {
    fontSize: 16,
    color: 'rgba(36,36,33,1)',
    background: 'rgba(36,36,33,0.1)',
    paddingBottom: 5,
    paddingTop: 5,
    paddingLeft: 8,
    paddingRight: 8,
    borderRadius: 3,
    width: '100%',
    '&:before': {
      backgroundColor: 'rgba(0,0,0,0)'
    },
    '&:after': {
      backgroundColor: 'rgba(0,0,0,0)'
    },
    '&:placeholder': {
      color: 'rgba(36,36,33,1)'
    }
  },
  formControl: {
    width: '100%',
    marginBottom: 24
  },
  searchInkbar: {
    '&:before': {
      backgroundColor: 'rgba(0,0,0,0) !important'
    },
    '&:after': {
      backgroundColor: 'rgba(0,0,0,0) !important'
    }
  },
  margin: {
    marginBottom: 24
  },
  button: {
    fontSize: 13,
    fontWeight: 'bold',
    fontFamily: '"BlissPro",sans-serif'
  },
  mrXlAuto: {
    [theme.breakpoints.up('md')]: {
      marginRight: 'auto'
    },
    [theme.breakpoints.down('md')]: {
      marginBottom: 16
    }
  },
  promoblock: {
    [theme.breakpoints.down('md')]: {
      order: 2
    }
  },
  itogoblock: {
    [theme.breakpoints.down('md')]: {
      order: 1
    },
    [theme.breakpoints.up('md')]: {
      marginLeft: 'auto',
      marginRight: 22
    }
  },
  paper: {
    boxShadow: 'none',
    borderRadius: 12,
    paddingTop: 16,
    paddingLeft: 24,
    paddingBottom: 16,
    paddingRight: 16,
    marginBottom: 10,
    border: '1px solid rgba(0,0,0,0.1);',
    fontSize: 16,
    fontFamily: '"BlissPro",sans-serif'
  },
  title: {
    marginBottom: 11,
    fontSize: 20,
    color: ' rgba(36,36,33,0.6);',
    fontFamily: '"BlissPro",sans-serif',
    fontWeight: 'normal'
  },
  primaryText: {
    fontSize: 16,
    fontFamily: 'BlissPro',
    marginBottom: 16
  },

  searchInputIcon: {
    color: 'rgba(97,97,97,1)',
    position: 'relative',
    top: 0
  },
  root: {
    color: '#120772',
    fontWeight: 'bold',
    opacity: 1,
    paddingTop: 32,
    justifyContent: 'flex-end',
    fontSize: 14,
    paddingBottom: 0
  },
  rootPrimarySelected: {
    color: '#000'
  },
  appBar: {
    fontSize: 1.4,
    backgroundColor: '#fff',
    fontWeight: 'bold',
    justifyContent: 'center',
    boxShadow: 'none'
  },
  menuItem: {
    fontSize: 14,
    fontWeight: 'bold'
  },
  tabButton: {
    fontSize: 14,
    fontWeight: 'bold',
    fontFamily: '"BlissPro",sans-serif',
    opacity: '1 !important'
  },
  bc: {
    color: '#000 !important'
  },
  rootTabPrimary: {
    minWidth: 0,
    color: '#120772',
    opacity: 1
  },
  menuFlexContainer: {
    justifyContent: ''
  },

  flexCol: {
    flexDirection: 'column',
    justifyContent: 'space-between',
    flexWrap: 'nowrap',
    height: '100%'
  },

  CatItemtitle: {
    fontSize: 17,
    fontWeight: 'bold',
    maxHeight: 66,
    marginBottom: 18,
    overflow: 'hidden'
  },
  text: {
    fontSize: 13,
    maxHeight: 54,
    overflow: 'hidden',
    marginBottom: 0
  },
  CatItemprice: {
    fontWeight: 'bold',
    fontSize: 19
  },
  secondary: {
    fontSize: 13,
    color: 'rgba(36,36,33,.3)'
  },

  PIprimaryText: {
    fontSize: 15,
    fontFamily: 'BlissPro',
    marginBottom: 16
  },
  paperFirst: {
    boxShadow: 'none',
    borderRadius: 12,
    paddingTop: 31,
    paddingLeft: 24,
    paddingBottom: 16,
    paddingRight: 64,
    [theme.breakpoints.down('lg')]: {
      paddingLeft: 20,
      paddingRight: 25
    },
    border: '1px solid rgba(0,0,0,0.1);',
    fontSize: 16,
    fontFamily: '"BlissPro",sans-serif'
  },
  paperSecond: {
    boxShadow: 'none',
    borderRadius: 12,
    paddingTop: 31,
    paddingLeft: 24,
    paddingBottom: 16,
    paddingRight: 64,
    [theme.breakpoints.down('lg')]: {
      paddingLeft: 32,
      paddingRight: 32
    },
    border: '1px solid rgba(0,0,0,0.1);',
    fontSize: 16,
    fontFamily: '"BlissPro",sans-serif'
  },
  heading: {
    fontSize: 18,
    color: '#242421',
    fontWeight: 'bold',
    marginBottom: 18
  },
  firstText: {
    width: 662,
    maxHeight: 62,
    overflow: 'hidden',
    [theme.breakpoints.down('lg')]: {
      width: 'auto',
      maxHeight: 255
    }
  },
  secondText: {
    maxHeight: 60,
    overflow: 'hidden',
    [theme.breakpoints.down('lg')]: {
      maxHeight: 355
    }
  },
  UBSbutton: {
    margin: theme.spacing.unit,
    fontSize: 13,
    marginLeft: 'auto',
    fontWeight: 'bold',
    fontFamily: '"BlissPro",sans-serif'
  },
  p0: {
    padding: 0
  },
  UBSprice: {
    fontSize: 24,
    color: '#242421',
    fontWeight: 'bold'
  },
  buttonContainer: {
    [theme.breakpoints.down('lg')]: {
      textAlign: 'left'
    },
    [theme.breakpoints.up('lg')]: {
      textAlign: 'center'
    }
  },
  hide: {
    maxHeight: 0,
    maxWidth: 0,
    display: 'none'
  },
  selectIcon: {
    color: '#6D6D6D',
    marginTop: 0
  },
  selectLine: {
    color: 'transparent'
  },
  textMain: {
    color: '#242421',
    fontSize: 16
  },
  textSecondary: {
    color: 'rgba(36,36,33,0.54)',
    fontSize: 14,
    marginBottom: 8
  },

  TournamentContentTabroot: {
    color: '#120772',
    fontSize: 1.4,
    fontWeight: 'bold',
    opacity: 1,
    paddingTop: 8,
    [theme.breakpoints.down('lg')]: {
      paddingLeft: 16,
      paddingRight: 16
    },
    [theme.breakpoints.up('lg')]: {
      paddingLeft: 168,
      paddingRight: 168
    }
  },
  tabs: {
    justifyContent: 'flex-end',
    fontSize: 14
  },
  tabScroller: {
    overflowX: 'scroll'
  },

  paperTournament: {
    [theme.breakpoints.up('lg')]: {
      paddingLeft: 32,
      paddingRight: 32,
      paddingTop: 40,
      paddingBottom: 16
    },
    [theme.breakpoints.down('lg')]: {
      paddingLeft: 32,
      paddingRight: 32,
      paddingTop: 24,
      paddingBottom: 16
    }
  },
  mainText: {
    fontSize: 16,
    marginBottom: 24,
    [theme.breakpoints.down('lg')]: {
      fontSize: 14
    }
  },
  buttonGreen: {
    fontSize: 14,
    fontWeight: 'bold',
    transform: 'translateX(-16px)'
  },
  bgGreen: {
    backgroundColor: '#005945 !important'
  },

  hasUpdates: {
    position: 'relative',
    '&:after': {
      content: '',
      position: 'absolute',
      width: 5,
      height: 5,
      backgroundColor: 'yellow',
      borderRadius: '100%',
      top: 0,
      right: 0
    }
  },
  iconbtn: {
    margin: 0,
    fontSize: 24,
    marginLeft: 'auto',
    fontWeight: 'bold',
    fontFamily: '"BlissPro",sans-serif',
    color: 'rgba(36,36,33,.54)',
    background: 'transparent',
    padding: 0,
    width: 24,
    height: 24,
    marginTop: -3
  },
  textGray: {
    color: 'rgba(36,36,33,0.6)'
  },
  dialogWindow: {
    borderRadius: 12
  },
  bgTransparent: {
    background: 'transparent'
  },
  dialogTitle: {
    color: '#242421',
    fontSize: 20,
    display: 'flex',
    fontWeight: 'bold',
    justifyContent: 'space-between',
    alignItems: 'center',
    backgroundColor: 'rgba(36,36,33,.04)',
    paddingTop: 24,
    paddingBottom: 21
  },
  cssLabel: {
    color: 'rgba(36,36,33,1)',
    fontWeight: 'bold',
    '&$cssFocused': {
      color: '#120772'
    },
    fontSize: 16
  },
  cssFocused: {},
  cssUnderline: {
    '&:after': {
      borderBottomColor: '#120772'
    }
  },
  inputRoot: {
    fontSize: 16
  },
  dialogContent: {
    maxWidth: 360,
    paddingBottom: 8
  },
  inputLabel: {
    fontSize: 14,
    lineHeight: 1
  },
  inputLabelShrink: {
    fontSize: 13,
    transform: 'translate(0, 1.5px) scale(1) !important'
  },
  radioLabel: {
    fontSize: 16,
    color: 'rgba(36,36,33)'
  },
  authDialog: {
    width: 464,
    height: 300,
    padding: 0,
    paddingTop: '0 !important'
  },
  thankDialog: {
    width: 464,
    height: 224,
    padding: 0,
    paddingTop: '0 !important'
  },
  regDialog: {
    width: 464,
    padding: 0,
    paddingTop: '0 !important'
  },
  authDialogHeader: {
    paddingLeft: 32,
    paddingRight: 21,
    backgroundColor: 'rgba(36, 36, 33,0.039)',
    paddingTop: 20,
    paddingBottom: 21
  },
  thankText: {
    fontSize: 40,
    color: 'white',
    lineHeight: 1.2,
    fontWeight: 'bold',
    textAlign: 'center',
    marginTop: 48,
    marginBottom: 39
  },
  thankDialogConatiner: {
    paddingLeft: 32,
    paddingRight: 21,
    backgroundColor: 'rgb(0, 118, 94)',
    paddingTop: 20,
    paddingBottom: 21
  },
  authDialogContent: {
    paddingLeft: 32,
    paddingRight: 32,
    paddingTop: 0
  },
  authTitle: {
    fontSize: 20,
    fontWeight: 'bold'
  },
  formControlmlmr: {
    [theme.breakpoints.down('md')]: {
      marginRight: 'auto'
    },
    [theme.breakpoints.up('md')]: {
      marginLeft: 'auto'
    }
  },
  selectRoot: {
    [theme.breakpoints.up('md')]: {
      marginRight: 116
    },
    [theme.breakpoints.down('md')]: {
      marginRight: 'auto'
    }
  },
  selectContainermlcenter: {
    [theme.breakpoints.up('lg')]: {
      marginLeft: 'auto'
    },
    [theme.breakpoints.down('lg')]: {
      display: 'flex',
      alignItems: 'center'
    }
  },
  select: {
    backgroundColor: 'rgba(36,36,33,0.1)',
    paddingLeft: 17,
    paddingTop: 12,
    paddingBottom: 10,
    paddingRight: 40,
    maxHeight: 40,
    [theme.breakpoints.up('md')]: {
      fontSize: 16
    },
    [theme.breakpoints.down('md')]: {
      fontSize: 12
    },
    color: '#242421',
    '&:after': {
      backgroundColor: '#242421'
    }
  },
  switchName: {
    color: '#005945',
    [theme.breakpoints.down('md')]: {
      fontSize: 14
    }
  },
  lgMlAuto: {
    [theme.breakpoints.up('lg')]: {
      marginLeft: 'auto'
    }
  },
  teamsContainer: {
    display: 'flex',
    flexDirection: 'column',
    [theme.breakpoints.down('lg')]: {
      maxHeight: 370,
      overflowY: 'hidden'
    },
    [theme.breakpoints.up('lg')]: {
      maxHeight: 375,
      flexWrap: 'wrap'
    }
  },
  teamItem: {
    marginBottom: 16,
    [theme.breakpoints.down('md')]: {
      paddingRight: 32,
      paddingLeft: 32
    }
  },
  paperTableTeams: {
    paddingTop: 24,
    paddingBottom: 16,
    [theme.breakpoints.up('md')]: {
      paddingRight: 32,
      paddingLeft: 32
    }
  },
  teamName: {
    [theme.breakpoints.down('lg')]: {
      textAlign: 'center',
      fontSize: 18
    },
    [theme.breakpoints.up('lg')]: {
      fontSize: 20,
      textAlign: 'left'
    }
  },
  imgFluid: {
    maxWidth: '100%'
  },
  xsMxAuto: {
    [theme.breakpoints.down('lg')]: {
      marginLeft: 'auto',
      marginRight: 'auto'
    }
  },
  iconChecked: {
    background: '#005945'
  },
  buttonStats: {
    fontSize: 13,
    fontWeight: 'bold',
    marginRight: 10,
    height: '45px'
  },
  iconbtnStats: {
    marginTop: 5,
    marginLeft: 'auto'
  },
  gray: {
    color: 'rgba(36,36,33,0.3)'
  },
  switchBase: {
    color: '#120772',
    '&$checked': {
      color: '#120772',
      '& + $bar': {
        backgroundColor: '#120772'
      }
    }
  },
  switchBar: {
    backgroundColor: '#120772'
  },
  avatar: {
    margin: 10
  },
  bigAvatar: {
    [theme.breakpoints.down('lg')]: {
      width: 60,
      height: 60
    },
    [theme.breakpoints.up('lg')]: {
      width: 90,
      height: 90
    }
  },
  sportsmanName: {
    [theme.breakpoints.down('lg')]: {
      fontSize: 18
    },
    [theme.breakpoints.up('lg')]: {
      fontSize: 24
    },
    fontFamily: '"BlissPro",sans-serif',
    color: 'black',
    fontWeight: 'bold'
  },
  sportsmanHeader: {
    alignItems: 'center',
    [theme.breakpoints.down('lg')]: {
      paddingLeft: 16,
      paddingRight: 16,
      paddingTop: 16,
      paddingBottom: 16
    },
    [theme.breakpoints.up('lg')]: {
      paddingLeft: 165,
      paddingRight: 165,
      paddingTop: 50,
      paddingBottom: 32
    },
    backgroundColor: '#fff',
    display: 'flex'
  },
  sportsmanRightSec: {
    justifyItems: 'flex-end',
    textAlign: 'right',
    color: '#242421',
    fontSize: 14,

    [theme.breakpoints.down('lg')]: {
      display: 'none'
    },
    [theme.breakpoints.up('lg')]: {
      display: 'block'
    }
  },
  sportsmanRatingNum: {
    fontSize: 40,
    color: '#242421',
    fontFamily: 'AkBarsFont'
  },
  mb16: {
    marginBottom: 16
  },
  textSecondaryfs16: {
    color: 'rgba(36,36,33,0.54)',
    fontSize: 16
  },
  borderBottom: {
    '&*:(not-last-of-type)': {
      borderBottom: '1px soldi red'
    }
  },
  inTableAvatar: {
    width: 36,
    height: 36,
    marginLeft: 16
  },
  schoolLink: {
    borderBottom: '1px solid rgba(36,36,33,0.2)',
    color: 'rgba(36,36,33,1)',
    '&:hover': {
      color: 'rgba(0,118,94,1)'
    }
  },

  tilePaper: {
    boxShadow: 'none',
    borderRadius: 12,
    paddingBottom: 16,
    paddingLeft: 24,
    paddingRight: 24,
    marginBottom: 10,
    border: '1px solid rgba(0,0,0,0.1);',
    fontSize: 16,
    fontFamily: '"BlissPro",sans-serif'
  },
  tileName: {
    color: 'rgba(36,36,33,1)',
    fontSize: 17,
    fontWeight: 'bold',
    marginTop: 36,
    marginBottom: 9
  },
  infoTitle: {
    color: 'rgba(36,36,33,0.6)',
    fontSize: 13
  },
  infoVal: {
    color: 'rgba(36,36,33,1)',
    fontSize: 15,
    marginTop: 5,
    fontWeight: 'bold'
  },
  tileAvatar: {
    width: 100,
    height: 100,
    margin: 'auto'
  },
  tileLink: {
    marginBottom: 16,
    fontSize: 15,
    borderBottom: '1px solid rgba(36,36,33,0.2)',
    color: 'rgba(36,36,33,1)',
    '&:hover': {
      color: 'rgba(0,118,94,1)'
    }
  },

  SPCroot: {
    color: '#120772',
    fontSize: 1.4,
    fontWeight: 'bold',
    opacity: 1
  },
  schoolMenuFlexContainer: {
    [theme.breakpoints.down('lg')]: {
      justifyContent: 'start',
      paddingLeft: 16,
      paddingRight: 16
    },
    [theme.breakpoints.up('lg')]: {
      justifyContent: 'center'
    }
  },
  building: {
    color: 'white',
    fontSize: '48px !important',
    backgroundColor: '#120772',
    borderRadius: '100%',
    padding: 24,
    width: 96,
    height: 96
  },
  schoolRightSec: {
    justifyItems: 'flex-end',
    textAlign: 'right',
    color: '#242421',
    fontSize: 14,
    marginLeft: 24
  },
  mlauto: {
    marginLeft: 'auto'
  },
  schoolRatingNum: {
    fontSize: '40px !important',
    color: '#242421',
    fontFamily: 'AkBarsFont'
  },
  xsh: {
    [theme.breakpoints.down('lg')]: {
      display: 'none'
    },
    [theme.breakpoints.up('lg')]: {
      display: 'block'
    }
  },
  newsPaper: {
    boxShadow: 'none',
    borderRadius: 12,
    paddingTop: 0,
    paddingLeft: 13,
    paddingRight: 16,
    paddingBottom: 26,
    marginBottom: 10,
    height: 395,
    border: '1px solid rgba(0,0,0,0.1);',
    fontSize: 16,
    fontFamily: '"BlissPro",sans-serif',
    overflow: 'hidden'
  },
  newsPaperPromo: {
    height: 185,
    marginLeft: -16,
    width: 'calc(100% + 34px)',
    marginBottom: 12
  },
  primaryTextfs14: {
    fontSize: 14,
    fontFamily: '"BlissPro",sans-serif',
    textOverflow: 'ellipsis',
    maxHeight: 140,
    overflow: 'hidden'
  },
  primaryBigText: {
    fontSize: 18,
    fontFamily: '"BlissPro",sans-serif',
    fontWeight: 'bold',
    display: 'block'
  },
  avatarw30: {
    width: 30,
    height: 30
  },
  linkfs13: {
    fontSize: 13,
    borderBottom: '1px solid rgba(36,36,33,0.2)',
    color: 'rgba(36,36,33,1)',
    '&:hover': {
      color: 'rgba(0,118,94,1)'
    }
  },
  w100: {
    width: '100%'
  },
  date: {
    fontSize: 13,
    color: 'rgba(36,36,33,0.6)'
  },
  newsTileHeader: {
    height: 43,
    overflow: 'hidden',
    lineHeight: 1.3,
    fontSize: 17,
    fontWeight: 'bold',
    position: 'relative',
    marginBottom: 10
  },
  newsTileText: {
    fontSize: 12,
    height: 47,
    lineHeight: 1.28,
    color: 'rgb(36, 36, 33)',
    overflow: 'hidden',
    marginBottom: 13
  },
  newsTileAuthor: {
    fontSize: 14,
    color: 'rgb(36,36,33)'
  },
  mb0: {
    marginBottom: 0
  },
  SIpaper: {
    boxShadow: 'none',
    borderRadius: 12,
    paddingTop: 28,
    paddingLeft: 25,
    paddingRight: 25,
    paddingBottom: 26,
    marginBottom: 10,
    border: '1px solid rgba(0,0,0,0.1);',
    fontSize: 16,
    fontFamily: '"BlissPro",sans-serif !important'
  },
  textCentered: {
    textAlign: 'center'
  },
  contactsPaper: {
    boxShadow: 'none',
    borderRadius: 12,
    paddingTop: 24,
    paddingLeft: 24,
    paddingRight: 32,
    paddingBottom: 21,
    marginBottom: 10,
    border: '1px solid rgba(0,0,0,0.1);',
    fontSize: 16,
    fontFamily: 'BlissPro',
    overflow: 'hidden'
  },
  map: {
    width: '100%',
    height: '100%',
    position: 'absolute',
    left: 0,
    top: 0,
    boxShadow: 'none',
    border: 0
  },
  mapContainer: {
    border: '1px solid rgba(0,0,0,0.1);',
    width: '100%',
    zIndex: 1,
    borderRadius: 12,
    overflow: 'hidden',
    minHeight: 372,
    position: 'relative'
  },
  secondaryText: {
    color: 'rgba(128,128,128,.6)',
    fontWeight: 'bold',
    fontSize: 14
  },
  iconGray: {
    color: 'rgba(191,191,184,1)',
    fontSize: 24
  },
  eventCell: {
    fontSize: 13,
    textOverflow: 'ellipsis',
    overflowX: 'hidden',
    maxWidth: '100%'
  },
  typography: {
    margin: theme.spacing.unit * 2
  },
  popoverPaper: {
    borderRadius: 20
  },
  popoverTopContainer: {
    padding: 24,
    backgroundColor: '#E43935',
    color: 'white'
  },
  whiteLink: {
    color: 'white',
    fontSize: 16,
    borderBottom: '1px solid rgba(255,255,255,.3)',
    transition: 'all .3s',
    '&:hover': {
      borderBottom: '1px solid rgba(255,255,255,.6)'
    }
  },
  name: {
    fontSize: 20,
    fontWeight: 'bold',
    lineHeight: '22px',
    color: 'white',
    marginBottom: 16
  },
  result: {
    fontSize: 16,
    lineHeight: '22px',
    color: 'white'
  },
  calendarbutton: {
    height: 24,
    width: 24,
    color: 'white'
  },
  description: {
    color: '#242421',
    fontSize: 16,
    lineHeight: '22px',
    display: 'flex',
    alignItems: 'center'
  },
  calendarsecondaryText: {
    fontSize: 14,
    color: 'rgba(36,36,33,.6)',
    marginBottom: 13
  },
  popoverBottomContainer: {
    padding: 24,
    paddingLeft: 0,
    paddingBottom: 6
  },
  descriptionContainer: {
    // padding:8,
    paddingLeft: 30,
    // paddingRight:12,
    paddingBottom: 24
  },
  calendaricon: {
    color: 'rgba(36,36,33,.3)',
    marginRight: 16
  },
  time: {
    fontSize: 13,
    opacity: 0.8,
    marginRight: 4
  },
  calendardescription: {
    color: '#242421',
    fontSize: 16,
    lineHeight: '22px',
    display: 'flex',
    alignItems: 'center'
  },
  GIpaper: {
    boxShadow: 'none',
    borderRadius: 12,
    paddingTop: 24,
    paddingLeft: 27,
    paddingBottom: 32,
    border: '1px solid rgba(0,0,0,0.1);',
    fontSize: 16,
    fontFamily: '"BlissPro",sans-serif'
  },
  GImainText: {
    color: '#242421',
    fontSize: 18,
    fontWeight: 'bold',
    paddingBottom: 0,
    marginBottom: 0
  },
  GIsecondaryText: {
    color: 'rgba(36,36,33,0.6)',
    fontSize: 14,
    paddingBottom: 0
  },

  STpaper: {
    boxShadow: 'none',
    borderRadius: 12,
    paddingTop: 24,
    paddingBottom: 16,
    marginBottom: 10,
    border: '1px solid rgba(0,0,0,0.1);',
    fontSize: 16,
    fontFamily: '"BlissPro",sans-serif'
  },
  STname: {
    color: 'rgba(36,36,33,1)',
    fontSize: 18,
    marginTop: 19,
    marginBottom: 19,
    textAlign: 'center'
  },
  STinfoContainer: {
    paddingLeft: 25,
    paddingRight: 25
  },
  STinfo: {
    minWidth: '50%'
  },
  STinfoTitle: {
    color: 'rgba(36,36,33,0.6)',
    fontSize: 14,
    marginTop: 16
  },
  STinfoVal: {
    color: 'rgba(36,36,33,1)',
    fontSize: 16,
    marginTop: 5
  },
  STavatar: {
    width: 100,
    height: 100,
    margin: 'auto'
  },
  marginA: {
    margin: 'auto'
  },
  STlink: {
    borderBottom: '1px solid rgba(36,36,33,0.2)',
    color: 'rgba(36,36,33,1)',
    '&:hover': {
      color: 'rgba(0,118,94,1)'
    }
  },
  trainerPaper: {
    boxShadow: 'none',
    borderRadius: 12,
    paddingTop: 16,
    paddingBottom: 16,
    marginBottom: 10,
    border: '1px solid rgba(0,0,0,0.1);',
    fontSize: 15,
    fontFamily: '"BlissPro",sans-serif',
    [theme.breakpoints.down('lg')]: {
      paddingLeft: 16,
      paddingRight: 16
    },
    [theme.breakpoints.up('lg')]: {
      paddingLeft: 24,
      paddingRight: 24
    }
  },
  trainerAvatar: {
    width: 56,
    height: 56
  },
  fio: {
    color: 'rgba(36,36,33,1)',
    fontSize: 15
  },
  trainLevel: {
    color: 'rgba(36,36,33,0.6)',
    fontSize: 13
  },
  trainerLink: {
    marginTop: 4,
    lineHeight: 1.6,
    color: 'rgba(36,36,33,1);',
    transition: 'all 0.4s',
    borderBottom: ' 1px solid rgba(36,36,33,0.2)',
    fontSize: 15,
    '&:hover': {
      transition: 'all 0.4s',
      borderBottomColor: 'rgba(36,36,33,.5)'
    }
  },

  header: {
    [theme.breakpoints.down('lg')]: {
      alignItems: 'start'
    },
    [theme.breakpoints.up('lg')]: {
      alignItems: 'center'
    }
  },
  schoolName: {
    fontFamily: '"BlissPro",sans-serif',
    color: 'black',
    fontWeight: 'bold',
    marginBottom: 16,
    [theme.breakpoints.down('lg')]: {
      fontSize: 18
    },
    [theme.breakpoints.up('lg')]: {
      fontSize: 24
    }
  },
  schoolHeader: {
    alignItems: 'center',
    [theme.breakpoints.down('lg')]: {
      paddingLeft: 16,
      paddingRight: 16,
      paddingTop: 16,
      paddingBottom: 16
    },
    [theme.breakpoints.up('lg')]: {
      paddingLeft: 165,
      paddingRight: 165,
      paddingTop: 50,
      paddingBottom: 32
    },
    backgroundColor: '#fff',
    display: 'flex'
    // borderBottom:'1px solid lightgray'
  },
  schoolAdress: {
    [theme.breakpoints.down('lg')]: {
      fontSize: 12
    },
    [theme.breakpoints.up('lg')]: {
      fontSize: 16
    },
    fontSize: 16,
    color: 'rgba(36,36,33,1)',
    position: 'relative',
    top: -5
  },
  mwformControl: {
    minWidth: 280,
    marginBottom: 24
  },
  grayText: {
    color: 'rgba(128,128,128,.6)',
    fontWeight: 'bold',
    fontSize: 14
  },

  newsHeading: {
    fontSize: 22,
    color: '#242421',
    fontWeight: 'bold',
    marginBottom: 40
  },
  newsText: {
    fontSize: 16,
    color: '#242421',
    marginBottom: 24
  },
  subHeader: {
    fontSize: 20,
    color: '#242421',
    fontWeight: 'bold',
    marginBottom: 24
  },
  promo: {
    width: '100%'
  },
  libformControl: {
    [theme.breakpoints.up('lg')]: {
      maxWidth: '30%',
      width: '30%'
    }
  },

  authoravatar: {
    width: 96,
    height: 96,
    margin: 'auto',
    marginBottom: 16
  },
  authorname: {
    color: '#242421',
    fontSize: 18,
    textAlign: 'center',
    maxWidth: 160,
    margin: 'auto',
    fontWeight: 'bold',
    marginBottom: 16
  },
  subtext: {
    fontSize: 14,
    color: 'rgba(36,36,33,.6)'
  },
  TabsRoot: {
    '&::-webkit-scrollbar': {
      display: 'none'
    }
  },
  AlphabetTabRoot: {
    minWidth: 10,
    color: '#00765E',
    maxHeight: 24,

    '&$disabledisabled': {
      color: '#123123'
    }
  },
  AlphabetTabLabel: {
    padding: '0 8px'
  },
  AlphabetTabLabeltext: {
    fontSize: 16
  },
  colorBlack: {
    color: '#242421 !important'
  },
  disabledTab: {
    fontSize: 16,
    color: 'rgba(36,36,33,0.6)'
  },
  scrollButtons: {
    maxWidth: 30,
    color: 'rgba(36,36,33,0.6)'
  },

  NIpaper: {
    boxShadow: 'none',
    borderRadius: 12,
    paddingBottom: 16,
    paddingLeft: 24,
    paddingRight: 24,
    paddingTop: 16,
    marginBottom: 10,
    border: '1px solid rgba(0,0,0,0.1);',
    fontSize: 16,
    fontFamily: '"BlissPro",sans-serif'
  },
  libItemDesc:{
    paddingLeft: 15,
    paddingRight: 15,
    paddingTop: 16,
    backgroundColor: 'white',
    flex: 1
  },
  libItemBottom:{
    backgroundColor: 'white',
    position: 'relative !important',
    top: '0 !important',
    right: '0 !important',
    float: 'right !important'
  },
  libItemTile: {
    boxShadow: 'none',
    borderRadius: 12,
    //paddingBottom: 16,
    //paddingLeft: 15,
    //paddingRight: 15,
    paddingTop: 16,
    marginBottom: 24,
    border: '1px solid rgba(0,0,0,0.1);',
    fontSize: 16,
    fontFamily: '"BlissPro",sans-serif',
    height: 494,
    //minWidth: 326,
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'flex-start',
    overflow: 'hidden'
  },
  libItemTilePicContainer: {
    width: 'calc(100% + 32px)',
    height: 185,
    marginLeft: -16,
    marginTop: -16,
    marginBottom: 16
  },
  libItemTilePic: {
    width: '100%',
    //maxHeight: 460
  },
  libItemTileHeading: {
    //maxHeight: 75,
    maxHeight: 50,
    overflow: 'hidden'
  },
  libItemTileText: {
    //maxHeight: 78,
    maxHeight: 55,
    overflow: 'hidden',
    marginBottom: 16
  },
  libLoader:{
    marginLeft: 'auto',
    marginRight: 'auto',
    marginTop: 50
  },
  libContentTitle: {
    marginBottom: 11,
    fontSize: 20,
    color: ' rgba(31,31,27,1);',
    fontFamily: '"BlissPro",sans-serif',
    fontWeight: 'bold'
  },
  libContentSubtitle: {
    fontSize: 16,
    margin: "24px 0 6px 0",
    fontWeight: 600,
    fontFamily: '"BlissPro", "sans-serif"'
  },
  avatarw32: {
    width: 32,
    height: 32
  },
  video: {
    width: '100%',
    minHeight: 234,
    border: 0
  },
  promoNews: {
    width: 'calc(100% + 48px)',
    position: 'relative',
    left: '-24px'
  },
  itemGallery: {
    width: '20%',
    '& img': {
      width: '100%'
    }
  },
  buttonChip: {
    fontSize: 14,
    color: 'rgba(36,36,33,0.6)',
    border: '1px solid rgba(36,36,33,0.3)',
    maxHeight: 28,
    backgroundColor: 'white',
    borderRadius: 2
  },
  NIheading: {
    fontSize: 20,
    color: 'rgba(36,36,33,1)',
    fontWeight: 'bold',
    lineHeight: 1.3
  },
  basicText: {
    fontSize: 16,
    color: 'rgba(36,36,33,1)',
    maxHeight: 70,
    overflow: 'hidden',
    marginTop: 10,
    textOverflow: 'ellipsis'
  },
  textDate: {
    fontSize: 12,
    color: 'rgba(36,36,33,0.6)'
  },
  NIicon: {
    color: 'rgba(36,36,33,0.3)'
  },
  iconText: {
    fontSize: 14
  },
  LIpaper: {
    paddingLeft: 82,
    paddingRight: 82,
    paddingTop: 24,
    paddingBottom: 34
  },
  LIheader: {
    fontSize: 24,
    color: 'rgba(36,36,33,1)',
    fontWeight: 'bold',
    marginBottom: 20
  },
  LItext: {
    fontSize: 16,
    color: 'rgba(36,36,33,1)',
    marginBottom: 24
  },
  img: {
    maxWidth: '100%',
    [theme.breakpoints.down('lg')]: {
      marginLeft: -16,
      marginRight: -16,
      maxWidth: 'calc(100% + 32px)'
    }
  },
  imgDescription: {
    color: 'rgba(36,36,33,0.3)',
    fontSize: 14,
    marginBottom: 33
  },
  flex: {
    flex: 1
  },
  menuButton: {
    marginLeft: -12,
    marginRight: 20
  },
  container: {
    display: 'flex',
    flexWrap: 'wrap'
  },
  inputLabelFocused: {
    color: teal[500]
  },
  inputInkbar: {
    '&:after': {
      backgroundColor: teal[500]
    }
  },
  textFieldRoot: {
    padding: 0,
    'label + &': {
      marginTop: theme.spacing.unit * 3
    }
  },
  textFieldInput: {
    borderRadius: 4,
    backgroundColor: theme.palette.common.white,
    border: '1px solid #ced4da',
    fontSize: 16,
    padding: '10px 12px',
    width: 'calc(100% - 24px)',
    transition: theme.transitions.create(['border-color', 'box-shadow']),
    '&:focus': {
      borderColor: '#80bdff',
      boxShadow: '0 0 0 0.2rem rgba(0,123,255,.25)'
    }
  },
  textFieldFormLabel: {
    fontSize: 18
  },
  lkBtn: {
    display: 'flex',
    alignItems: 'center',
    color: 'white',
    fontSize: 14,
    textTransform: 'capitalize'
  },
  lkpopover: {
    marginTop: 40
  },
  lkpaper: {
    width: 150,
    borderRadius: 5,
    boxShadow: 'none',
    border: '1px solid rgba(0,0,0,.2)'
  },
  headerMenuItem: {
    padding: '8px 8px',
    fontSize: 14,
    color: 'rgba(36,36,33)',
    '&:first-of-type': {
      borderBottom: '1px solid rgba(36,36,33,.1)'
    },
    '&:last-of-type': {
      borderTop: '1px solid rgba(36,36,33,.1)'
    }
  },
  avatarw100: {
    width: 100,
    height: 100
  },
  trainerName: {
    color: 'rgba(36,36,33,1)',
    fontSize: 18,
    marginTop: 0,
    marginBottom: 16,
    textAlign: 'center'
  },
  trainerInfoTitle: {
    color: 'rgba(36,36,33,0.6)',
    fontSize: 14,
    textAlign: 'center'
  },
  dateicon: {
    color: 'rgba(36,36,33,0.2)',
    fontSize: 24,
    position: 'relative',
    top: 4
  },
  datetext: {
    fontSize: 16,
    color: '#242421'
  },
  score: {
    fontSize: 40,
    color: '#242421',
    textAlign: 'center',
    fontWeight: 'bold'
  },
  datename: {
    fontSize: 18,
    color: '#242421',
    fontWeight: 'bold',
    textAlign: 'center'
  },
  secondScore: {
    fontSize: 14,
    color: 'rgba(36,36,33,0.2)'
  },
  dot: {
    color: 'rgba(36,36,33,0.2)',
    fontSize: 16
  },
  responsivePhoto: {
    objectFit: 'cover'
  },
  searchControl: {}
})

export default styles
