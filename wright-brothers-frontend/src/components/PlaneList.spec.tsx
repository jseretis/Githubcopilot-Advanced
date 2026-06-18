import { test, expect } from '@playwright/experimental-ct-react';
import PlaneList from './PlaneList';
import type { HooksConfig } from '../../playwright';

test('should navigate when clicking on a plane', async ({ page, mount }) => {
  const planes = [
    { id: 1, name: "Wright Flyer", year: 1903 },
    { id: 2, name: "Wright Model A", year: 1905 },
    { id: 3, name: "Wright Model B", year: 1910 },
  ];

  const component = await mount<HooksConfig>(<PlaneList planes={planes} />, {
    hooksConfig: { routing: true },
  });

  await component.locator('[class*="cursor-pointer"]').nth(0).click();

  await expect(page).toHaveURL('/planes/1', { timeout: 5000 });
});