export const homeObjOne = {
  id: "about",
  lightBackground: true,
  lightText: false,
  lightTextDesc: false,
  topLine: "Teamwork makes the dream work",
  headLine: "It’s a way of working together.",
  description: "Manage projects, organize tasks, and build team spirit—all in one place.",
  buttonLabel: "Learn more",
  imgStart: false, //switch between col1 & col2
  img: require('../../images/svg-1.svg').default, //react-script version bug, default is needed at the end of require or else it wont display image
  alt: "teamwork",
  dark: false,
  primary: false,
  darkText: true,
};

export const homeObjTwo = {
  id: "discover",
  lightBackground: true,
  lightText: false,
  lightTextDesc: false,
  topLine: "dive into the details",
  headLine: "Cards contain everything you need.",
  description: "Cards are your portal to more organized work—where every single part of your task can be managed, tracked, and shared with teammates.",
  buttonLabel: "Learn more",
  imgStart: true, //switch between col1 & col2
  img: require('../../images/svg-2.svg').default, //react-script version bug, default is needed at the end of require or else it wont display image
  alt: "cards",
  dark: true,
  primary: true,
  darkText: true,
};

export const homeObjThree = {
  id: "",
  lightBackground: true,
  lightText: false,
  lightTextDesc: false,
  topLine: "deja vu",
  headLine: "Complete project before deadline.",
  description: "With our features give any team the overview of the procject & ability to quickly set up and complete tasks before deadline.",
  buttonLabel: "Learn more",
  imgStart: false, //switch between col1 & col2
  img: require('../../images/svg-3.svg').default, //react-script version bug, default is needed at the end of require or else it wont display image
  alt: "complete tasks",
  dark: true,
  primary: true,
  darkText: true,
};
