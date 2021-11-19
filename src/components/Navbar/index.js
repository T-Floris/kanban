import React, { useEffect, useState } from "react";
import { FaBars } from "react-icons/fa";
// import { IconContext } from "react-icons/lib";
import { animateScroll as scroll } from "react-scroll";
import {
  Nav,
  NavbarContainer,
  NavLogo,
  MobileIcon,
  NavMenu,
  NavItem,
  NavLinks,
  NavBtn,
  NavBtnLink,
} from "./NavbarElements";

const Navbar = ({ toggle }) => {

  //navbars background changes color when scrolled
  const [scrollNav, setScrollNav] = useState(false);
  const changeNav = () => {
    if (window.scrollY >= 80) {
      setScrollNav(true);
    } else {
      setScrollNav(false);
    }
  };
  useEffect(() => {
    window.addEventListener("scroll", changeNav);
  }, []);

  //scrolling to top
  const toggleHome = () => {
    scroll.scrollToTop();
  };

  return (
    <>
      {/* <IconContext.Provider value={{ color: '#fff'}}> */}{" "}
      {/* controlls colors of all icons from react-icons */}
      
      <Nav scrollNav={scrollNav}>
        <NavbarContainer>
          <NavLogo to="/" onClick={toggleHome}>
            KanBan
          </NavLogo>{" "}
          {/* scrolling to top when clicked */}
          <MobileIcon onClick={toggle}>
            <FaBars />
          </MobileIcon>
          <NavMenu>
            <NavItem>
              <NavLinks
                to="about"
                //smooth scroll below
                smooth={true}
                duration={500}
                spy={true}
                exact="true"
                offset={-80}
              >
                About
              </NavLinks>
            </NavItem>
            <NavItem>
              <NavLinks
                to="discover"
                smooth={true}
                duration={500}
                spy={true}
                exact="true"
                offset={-80}
              >
                Discover
              </NavLinks>
            </NavItem>
            <NavItem>
              <NavLinks
                to="services"
                smooth={true}
                duration={500}
                spy={true}
                exact="true"
                offset={-80}
              >
                Services
              </NavLinks>
            </NavItem>
            {/* <NavItem>
              <NavLinks to="signup">Sign Up</NavLinks>
            </NavItem> */}
          </NavMenu>
          <NavBtn>
            <NavBtnLink to="/signin">Sign Up</NavBtnLink>
            <NavBtnLink to="/signin">Sign In</NavBtnLink>
            <NavBtnLink to="/boardPage">Board</NavBtnLink>
          </NavBtn>
        </NavbarContainer>
      </Nav>
      {/* </IconContext.Provider> */}
    </>
  );
};

export default Navbar;
