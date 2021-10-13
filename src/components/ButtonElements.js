import styled from "styled-components";
import { Link } from "react-scroll";
import { Link as LinkRouter } from "react-router-dom";

export const Button = styled(Link)`
  border-radius: 50px;
  background: ${({ primary }) => (primary ? "#562BF6" : "#010606")};
  white-space: nowrap;
  padding: ${({ big }) => (big ? "14px 48px" : "12px 30px")};
  color: ${({ dark }) => (dark ? "#010606" : "#fff")};
  font-size: ${({ fontBig }) => (fontBig ? "20px" : "16px")};
  outline: none;
  border: none;
  cursor: pointer;
  display: flex;
  justify-content: center;
  align-items: center;
  transition: all 0.2s ease-in-out;
  font-weight: bold;

  &:hover {
    transition: all 0.2s ease-in-out;
    background: ${({ primary }) => (primary ? "#010606" : "#562BF6")};

    /* color: ${({ primary }) => (primary ? "#010606" : "#562BF6")}; */

    color: ${({ primary }) => (primary ? "#fff" : "#562BF6")};
  }
`

export const ButtonTransparent = styled(LinkRouter)`
background-color: rgba(255, 255, 255, 0);
  color: ${({ dark }) => (dark ? "#fff" : "#010606")};
  white-space: nowrap;
  font-size: ${({ fontBig }) => (fontBig ? "20px" : "16px")};
  font-weight: bold;
  border: 3px solid #fff;
  padding: ${({ big }) => (big ? "14px 48px" : "12px 30px")};
  text-transform: uppercase;
  transition: background-color 0.5s ease-out;
  margin-top: 30px;
  cursor: pointer;
  display: flex;
  justify-content: center;
  text-decoration: none;

  &:hover {
    transition: all 0.2s ease-in-out;
    background: ${({ primary }) => (primary ? "#fff" : "#562BF6")};

    color: ${({ primary }) => (primary ? "#010606" : "#562BF6")};;
  }
  `