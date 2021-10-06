export const homeObjOne = {
  id: "about",
  lightBackground: false,
  lightText: true,
  lightTextDesc: true,
  topLine: "test",
  headLine: "headline",
  description: "something",
  buttonLabel: "Get started",
  imgStart: false, //switch between col1 & col2
  img: require('../../images/svg-1.svg').default, //react-script version bug, default is needed at the end of require or else it wont display image
  alt: "test",
  dark: true,
  primary: true,
  darkText: false,
};

export const homeObjTwo = {
  id: "discover",
  lightBackground: true,
  lightText: false,
  lightTextDesc: false,
  topLine: "test",
  headLine: "headline",
  description: "something",
  buttonLabel: "Get started",
  imgStart: true, //switch between col1 & col2
  img: require('../../images/svg-2.svg').default, //react-script version bug, default is needed at the end of require or else it wont display image
  alt: "test",
  dark: false,
  primary: false,
  darkText: true,
};

export const homeObjThree = {
  id: "services",
  lightBackground: true,
  lightText: false,
  lightTextDesc: false,
  topLine: "test",
  headLine: "headline",
  description: "something",
  buttonLabel: "Get started",
  imgStart: false, //switch between col1 & col2
  img: require('../../images/svg-3.svg').default, //react-script version bug, default is needed at the end of require or else it wont display image
  alt: "test",
  dark: false,
  primary: false,
  darkText: true,
};
